                using (System.IO.StreamReader reader = new System.IO.StreamReader(Path.Combine(@"c:\temp\", "test.txt")))  // replaces sigCheckProcess.StandardOutput
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        writer.WriteLine(line);
                    }
                }
            }
