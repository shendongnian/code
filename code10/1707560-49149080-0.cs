        static void SecondMenu()
        {
            char sel2; // Selection variable, used in user's input to get to the desired operation
            // Display Menu Options
            Console.WriteLine("");
            Console.WriteLine("********************");
            Console.WriteLine("A. Addition");
            Console.WriteLine("S. Substraction");
            Console.WriteLine("D. Division");
            Console.WriteLine("********************");
            Console.Write("Please enter your option here:   ");
            sel2 = Convert.ToChar(Console.ReadLine());
            switch (sel2)
            {
                case 'a':
                    Calc(1);
                    break;
                case 's':
                    Calc(2);
                    break;
                case 'd':
                    Calc(3);
                    break;
                default:
                    Console.WriteLine("Wrong entry! Try again");
                    MainMenu();
                    return;
            }
        }
        static void Calc(int f)
        {
            double num1, num2, res;
            try
            {
                Console.Write("Please enter the first number: ");
                num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Please enter the second number: ");
                num2 = Convert.ToDouble(Console.ReadLine());
                switch (f)
                {
                    case 1:
                        res = num1 + num2;
                        break;
                    case 2:
                        res = num1 - num2;
                        break;
                    case 3:
                        res = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Wrong entry! Try again");
                        MainMenu();
                        return;
                }
                Console.WriteLine("RESULT:  " + res);
                Console.WriteLine("");
                Console.ReadKey(true);
                MainMenu();
            }
            catch
            {
                Console.WriteLine("Wrong entry! Try again");
                MainMenu();
            }
        }
    
