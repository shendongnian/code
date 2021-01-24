        // Displays the map to the player
        public static void DisplayMap()
        {
            // Clear the console so we can redisplay the map
            Console.Clear();
            // For all rows
            for (int row = 0; row < 32; row++)
            {
                // For all columns
                for (int col = 0; col < 128; col++)
                {
                    // Get the right colour
                    Console.ForegroundColor = map[row, col].colour;
                    // Write the character
                    Console.Write(map[row, col].character);
                }
                Console.WriteLine();
            }
        }
