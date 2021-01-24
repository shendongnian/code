    for (int j = 0; j < 10; j++)
                {
                    string line = "";
                    for (int i = 0; i <= a.Length - 1; i++)
                    {
                        if (a[i] >= 10 * (10 - j))
                        {
                            line = line+"*";
                        }
                        else 
                        { 
                            line = line+"p"; 
                        }
                    }
                    Console.WriteLine(line);
                }
