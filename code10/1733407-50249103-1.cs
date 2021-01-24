     while (!sr.EndOfStream)
            {
                this.position = sr.BaseStream.Position;
                try
                {
                    var line = sr.ReadLine();
                    if (line != string.Empty)
                    {
                        this.Contents.Add(line);
                        newLines.Add(line);
                        Console.WriteLine(line);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing line in {fullPath}");
                    throw;
                }
            }
