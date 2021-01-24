        private static void MainMenu()
        {
            ClearAndWriteHeading("Car Dealership Sales Tracker - Main Menu");
            Console.WriteLine("1: Display employee of the week information");
            Console.WriteLine("2: Display total number of cars sold by the company");
            Console.WriteLine("3: Write all sales data to a text file");
            Console.WriteLine("4: Generate new weekly sales info");
            Console.WriteLine("5: Exit program\n");
            Console.Write("Enter option number 1 - 5: ");
            // Get input from user (ensure they only enter 1 - 5)
            int input;
            while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out input) ||
                input < 1 || input > 5)
            {
                // Erase input and wait for valid response
                Console.SetCursorPosition(0, 8);
                Console.Write("Enter option number 1 - 5:  ");
                Console.SetCursorPosition(Console.CursorLeft - 1, 8);
            }
            ProcessMenuItem(input);
        }
