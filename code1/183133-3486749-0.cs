     void ConvertFile(string inPath, string outPath)
        {
            using (var reader = new StreamReader(inPath))
            {
                using (var writer = new StreamWriter (outPath))
                {
                    string line = reader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        writer.WriteLine("buildLetter.Append(\"{0}\").AppendLine();",line);
                        line = reader.ReadLine ();
                    }    
                }
            }
        }
