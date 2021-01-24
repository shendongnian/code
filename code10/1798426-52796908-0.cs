     int entered_number = 0;
            do
            {
                //ask for user entry
                Console.Write("enter a number: ");
                entered_number = int.Parse(Console.ReadLine());
                if (entered_number < 0)
                {
                    Console.WriteLine("Number is negative");
                }
                else if (entered_number > 0)
                {
                    Console.WriteLine(IsPrimeNumber(entered_number) ? "Number is Prime" : "Number is not Prime");
                }
                else
                {
                    break;
                }
            }
            while (entered_number != 0);
            Console.WriteLine("End of program");
            Console.ReadKey();
