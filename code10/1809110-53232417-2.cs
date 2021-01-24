    while ((inLine = inFile.ReadLine()) != null)
                    {
                        var splits = inLine.Split(new[] { ' ', '\'' }, StringSplitOptions.RemoveEmptyEntries);
                        if (splits.Length > 0)
                        {
                            Console.WriteLine($"First Name - {splits[2]}, Last Name - {splits[3]}, Email - {splits[7]}");
                        }
                    }
