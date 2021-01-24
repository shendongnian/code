                var index = 3;
                foreach (var item in str)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                       
                        Console.Write(item[i]);
                        
                        Console.ForegroundColor = (ConsoleColor)index;
                        index++;
                        if (index == 15)
                            index = 3;
                        if (i == item.Length - 1)
                        {
                            Console.Write("\n");
                            continue;
                        }
                    }
                }
