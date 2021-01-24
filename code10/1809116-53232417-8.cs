     while ((inLine = inFile.ReadLine()) != null)
                {
                    var splits = inLine.Split(new[] { ' ', '\'' }, StringSplitOptions.RemoveEmptyEntries);
                    if (splits.Length > 0)
                    {
                        Console.WriteLine("Last Name - " + splits[2]);
                        Console.WriteLine("First Name - " + splits[3]);
                        Console.WriteLine("Middle Initial - " + splits[4]);
                        Console.WriteLine("Phone - " + splits[6]);
                        Console.WriteLine("Email - " + splits[7]);
                        Console.WriteLine("GPA - " + splits[8]);
                    }
                    Console.WriteLine("------------------------------------------------------");
                }
