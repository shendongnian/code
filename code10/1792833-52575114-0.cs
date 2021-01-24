     static String promptRedo()
        { 
            String anotherGame = ""
            do{
            Console.Write("Would you like to play another game? (Y/N) => ");
            String input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                anotherGame = "y";
            }
            else if (input.Equals("n"))
            {
                // get any key from user to exit program
                Console.WriteLine();
                Console.WriteLine("Thank you for playing!");
                Console.WriteLine("Press any key to exit ...");
                Console.ReadKey();
                anotherGame = "n";
                Console.WriteLine(anotherGame);
            }
            else
            {
                Console.WriteLine("ERROR: Invalid input (Y/N) only!");
                promptRedo(anotherGame);
            }
            }while(anotherGame!="y"&&anotherGame!="n")
            return anotherGame;
        }
