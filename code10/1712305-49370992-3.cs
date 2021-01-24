        private static void Main()
        {
            string[,] table = new string[5, 5];
            FillCard(table);
            DisplayBingoCard(table);
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
