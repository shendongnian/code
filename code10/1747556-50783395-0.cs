     using System;
    namespace ConsoleApp3
    {
        class Program
    
        {
    
            static void Main(string[] args)
            {
                 someFunction();
            }
    
    
            static void someFunction()
            {
                Random numberGenerator = new Random();
    
                int num1 = numberGenerator.Next(1, 11);
                int num2 = numberGenerator.Next(1, 4);
    
    
                Console.WriteLine("What is " + num1 + " times " + num2 + "?");
    
    
                int svar = Convert.ToInt32(Console.ReadLine());
    
                if (svar == num1 * num2)
                {
                    Console.WriteLine("well done!");
                }
                else
                {
                    int responseIndex = numberGenerator.Next(1, 4);
    
                    switch (responseIndex)
                    {
                        case 1:
                            Console.WriteLine("Wrong, try again? [Y or N]");
                            AskUser();
                            break;
                        case 2:
                            Console.WriteLine("The answer was incorrect");
                            AskUser();
                            break;
                        default:
                            Console.WriteLine("You can do better than that");
                            AskUser();
                            break;
                    }
                }
            }
    
            static void AskUser()
            {
                string jaellernei = Console.ReadLine().ToUpper();
                if (jaellernei == "Y")
                {
                    someFunction();
                }
                else
                {
                    return;
                }
            }
    
    
        }
    }
