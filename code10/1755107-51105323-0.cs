                int min = 0;
                int max = 6;
                Random randnum = new Random();//random number generator
                int[] numbers = new int[6];// generates six numbers
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = randnum.Next(min, max);//sets the numbers between 0 to 6
                    if (isValueInArray(i, numbers))
                    {
                        numbers[i] = randnum.Next(min, max);
                    }
                }
    
                try
                {
                    Console.WriteLine("Hello and Welcome to our little game of lottery! lets see just how much luck you got!"); // greetings and instructions
                    Console.WriteLine("You'll now get to choose 6 different numbers between 0 to 6 to play with.");
                    Console.WriteLine("Go ahead and type them in.");
    
                    int[] lottery = new int[6];
    
                    int x = 0;
                    //read user numbers
                    for (int i = 0; i < lottery.Length; i++)
                    {
                        lottery[i] = int.Parse(Console.ReadLine()); // array to catch six numbers input
                        while (lottery[i] > 6)//checking if the numbers fit between 0 and 6
                        {
                            Console.WriteLine("whoops! the number you enetered isn't in range! please try again ^^");
                            lottery[i] = int.Parse(Console.ReadLine()); // array to catch six numbers input
                        }
                    }
    
                    //count number of matches
                    for (int a = 0; a < lottery.Length; a++)
                    {
                        for (int b = 0; b < numbers.Length; b++)
                        {
                            if (lottery[a] == numbers[b])
                            {
                                //a++;
                                x++;
                                break;
                            }
                        }
                    }
    
                    //display results
                    if (x == 6)
                    {
                        Console.WriteLine("six matches");
                    }
                    else if (x == 5)
                    {
                        Console.WriteLine("five matches");
                    }
                    else if (x == 4)
                    {
                        Console.WriteLine("four matches");
                    }
                    else if (x == 3)
                    {
                        Console.WriteLine("three matches");
                    }
                    else if (x == 2)
                    {
                        Console.WriteLine("two matches");
                    }
                    else if (x == 1)
                    {
                        Console.WriteLine("one match");
                    }
    
                }
    
                catch (FormatException)// checking if the input is in char format
                {
                    Console.WriteLine("only numbers please!");
                }
                Console.Read();
            }
