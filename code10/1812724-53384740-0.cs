        static void Main()
        {
            //Array For Ticket prices, sales and user input
            var ticketChoices = new int[3];
            //Ticket Types
            //ChildT = £1.50 = Child;
            //AdultT = £2.35 = Adult;
            //StudentT = £1.99 = Student;
            //Film      Certificate     Seats   Screen
            //Jaws          12A          15       1
            //The Exorcist  18           33       2
            Console.WriteLine("Hello Current tickets are:");
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("ID (1) Child, £1.50");
                Console.WriteLine("ID:(2) Adult, £2,35");
                Console.WriteLine("ID:(3) Student £1.99");
                Console.WriteLine("");
                Console.WriteLine("Please Select Which ticket you would like to input By Entering it's id Number");
                Console.WriteLine("input Must be between 1-3 for it to be vaild.");
                var valid = false;
                while (!valid)
                {
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out var ticketNumber))
                    {
                        if (ticketNumber >= 0 && ticketNumber <= 3)
                        {
                            valid = true; 
                        }
                    }
                    if (valid)
                    {
                        ticketChoices[i] = ticketNumber;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a value between 1 and 3");
                    }
                }
            }
            // Print the results 
            Console.WriteLine("You entered:");
            foreach (var ticketChoice in ticketChoices)
            {
                Console.WriteLine(ticketChoice);
            }
            Console.ReadLine();
        }
