    int[] array = new int[9];
                int userInput = -1;
                int itt = 0;
                int count = 0;
    
                Console.WriteLine("Enter a integer number or -1 to exit:");
                userInput = Convert.ToInt32(Console.ReadLine());
                count++;
                while (userInput != -1 && itt < array.Length)
                {
    
                    array[itt] = userInput;
                    itt++;
                    if (count == 9) break;
                    Console.WriteLine("Enter a integer number or -1 to exit:");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    count++;
                }
                Console.WriteLine("The array contains: ");
    
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(" {0} , ", array[i]);
    
                }
                Console.WriteLine("");
                Console.WriteLine("count {0}", count);
    
                if (count % 2 == 0)
                {
                    for (int i = 0; i < array.Length; i += 2)
                    {
                        Console.Write(" {0} , ", array[i] * array[i + 1]);
                    }
                }
                else
                {
                    for (
                        
                        
                        
                        int i = 0; i < array.Length; i += 1)
                    {
                        if (i == 7)
                        {
                            Console.Write(" {0} , ", array[i] * array[i + 1]);
                            break;
                        }
                        
                        Console.Write(" {0} , ", array[i] * array[i + 1]);
                        
    
                    }
                }
    
                Console.ReadLine()
;
