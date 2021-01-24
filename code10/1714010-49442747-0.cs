    public static bool playAgainn()
            {
                Console.WriteLine("Do you want to play again?(y/n)");
                string loop = Console.ReadLine();
                if (loop == "y")
                {
                    Console.Clear();
                    return true;
                }
                else 
                {
                    return false;
                }
            }
