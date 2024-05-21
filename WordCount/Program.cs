using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: WordCount.exe -c|-w <input_file_name>");
            return;
        }

        string parameter = args[0];
        string inputFileName = args[1];

        if (!File.Exists(inputFileName))
        {
            Console.WriteLine($"Error: File '{inputFileName}' not found.");
            return;
        }

        string content = File.ReadAllText(inputFileName);

        if (parameter == "-c")
        {
            int charCount = content.Length;
            Console.WriteLine($"字符数：{charCount}");
        }
        else if (parameter == "-w")
        {
            int wordCount = CountWords(content);
            Console.WriteLine($"单词数：{wordCount}");
        }
        else
        {
            Console.WriteLine("Invalid parameter. Use -c for character count or -w for word count.");
        }
    }

    static int CountWords(string content)
    {
        char[] delimiters = { ' ', '\t', '\n', ',' };
        string[] words = content.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}
