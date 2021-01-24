     int[] lottonumbers = new int[10];
            Random number = new Random();
            int lottonumber = number.Next(1, 26);
            Console.WriteLine("{0}", lottonumber);
            bool match = false;
            Console.WriteLine("Hi and welcome to Bingo!");
            for (int i = 0; i < lottonumbers.Length; i++)
            {
                Console.WriteLine("You must enter 10 bingo numbers.Only numbers between 1 - 25 are valid!");
                int element = 0;
                if (int.TryParse(Console.ReadLine(), out element))
                {
                	if (element >= 1 && element <= 25) 
                    {
						lottonumbers[i] = element;
                    }
                    else 
                    {
                    	Console.WriteLine("Only numbers between 1 and 25 are valid, write again");
						--i;
                    }
                }
                else
                {
                    Console.WriteLine("No letters are valid, only numbers(integers).");
                    --i;
                }
            }
            for (int i = 0; i < lottonumbers.Length; i++)
            {
                if (lottonumbers[i] == lottonumber)
                {
                    match = true;
                }
            }
            if (match == true)
            {
                Console.WriteLine("Bingo number {0} matched! You got Bingo!", lottonumber);
            }
            else
            {
                Console.WriteLine("There was no bingo!");
            }
            
			Console.ReadKey(true);
