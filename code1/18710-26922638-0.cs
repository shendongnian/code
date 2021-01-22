            int myNumber;
            Guess: Console.Write("Guess a number between 20 through 25: ");
            myNumber = int.Parse(Console.ReadLine());
                while(myNumber != 25)
                {
                    Console.WriteLine("Keep Guessing");
                    goto Guess;
                }
                Console.Write("Merry Christmas");
            Console.ReadKey();
