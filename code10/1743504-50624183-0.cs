    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                string path = args[0];
                EditFile(new List<string>() { "CM", "Filling" }, path);
            }
            Console.Read();
        }
        public static void EditFile(List<string> keyWords, string filename)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (sr.Peek() >= 0)
                {
                    lines.Add(sr.ReadLine());
                }
                sr.Close();
            }
            int removedLinesCount = 0;
            bool writeline;
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var line in lines)
                {
                    writeline = true;
                    foreach (var str in keyWords)
                    {
                        if (line.Contains(str))
                        {
                            writeline = false;
                            removedLinesCount++;
                            break;
                        }
                    }
                    if (writeline)
                        sw.WriteLine(line);
                }
                Console.WriteLine(removedLinesCount + " lines removed from the file " + filename);
                sw.Close();
            }
        }
    }
