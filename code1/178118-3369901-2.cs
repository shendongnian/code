    class Program
    {
        static void Main(string[] args)
        {
            var records = ReadFile(@"D:\x.txt");
    
            foreach (var record in records)
            {
                foreach (var field in record)
                {
                    Console.Write(field + " | ");
                }
    
                Console.WriteLine();
            }
    
            Console.ReadKey();
        }
    
        static IEnumerable<IEnumerable<String>> ReadFile(String file)
        {
            using (var reader = new StreamReader(file))
            {
                // Ignore column titles line.
                reader.ReadLine();
    
                while (!reader.EndOfStream)
                {
                    yield return GetFields(reader.ReadLine());
                }
            }
        }
    
        static IEnumerable<String> GetFields(String line)
        {
            Int32 quoteCount = 0;
            StringBuilder field = new StringBuilder();
    
            foreach (var c in line)
            {
                if (c == '"')
                {
                    quoteCount++;
                    continue;
                }
    
                if (quoteCount % 2 == 0)
                {
                    if (c == ' ')
                    {
                        if (field.Length > 0)
                        {
                            yield return field.ToString();
                            field.Length = 0;
                        }
                    }
                    else
                    {
                        field.Append(c);
                    }
                }
                else
                {
                    field.Append(c);
                }
            }
    
            yield return field.ToString();
        }
    }
