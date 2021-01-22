    class Program
    {
        static IEnumerable<String> Visitor(String root, String searchPattern)
        {
            foreach (var file in Directory.GetFiles(root, searchPattern, SearchOption.TopDirectoryOnly))
            {
                yield return file;
            }
    
            foreach (var folder in Directory.GetDirectories(root))
            {
                foreach (var file in Visitor(folder, searchPattern))
                    yield return file;
            }
        }
    
        static void Main(string[] args)
        {
            foreach (var file in Visitor(args[0], args[1]))
            {
                Console.Write("Process {0}? (Y/N) ", file);
    
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("{1}\tProcessing {0}...", file, Environment.NewLine);
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
