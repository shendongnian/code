            static void Main(string[] args)
        {
            bool exit = false;
            List<float> grades = new List<float>();
            do
            {
                Console.WriteLine("1. Enter Grades");
                Console.WriteLine("2. Get Average");
                Console.WriteLine("3. My program");
                Console.WriteLine("4. exit");
                Console.WriteLine("");
                string input = Console.ReadLine();
                Console.WriteLine("");
                if (input == "1")
                {
                    int totalGrades = 0;
                    //User Input
                    Console.WriteLine("How many grades do you want to enter? ");
                    while (true)
                    {
                        try
                        {
                            totalGrades = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("This is not a valid number");
                            continue;
                        }
                    }
                    Console.WriteLine("");
                    while (totalGrades > 0)
                    {
                        while (true)
                        {
                            try
                            {
                                grades.Add(Convert.ToInt32(Console.ReadLine()));
                                totalGrades--;
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("This is not a valid number");
                                continue;
                            }
                        }
                    }
                    Console.WriteLine("");
                }
                else if (input == "2")
                {
                    double average = grades.Average();
                    if (average >= 90)
                    {
                        Console.WriteLine($"The average is a {average} which is an A.");
                    }
                    else if (average >= 80)
                    {
                        Console.WriteLine($"The average is a {average} which is an B.");
                    }
                    else if (average >= 70)
                    {
                        Console.WriteLine($"The average is a {average} which is an C.");
                    }
                    else if (average >= 60)
                    {
                        Console.WriteLine($"The average is a {average} which is an D.");
                    }
                    else
                    {
                        Console.WriteLine($"The average is a {average} which is an E.");
                    }
                    Console.WriteLine("");
                }
                else if (input == "4")
                {
                    exit = true;
                } else
                {
                    Console.WriteLine("This is not an option");
                }
            }
            while (exit == false);
        }
