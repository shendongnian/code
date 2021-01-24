        private static void WriteSalesToFile(string errorMessage = null)
        {
            ClearAndWriteHeading("Car Dealership Sales Tracker - Write Sales Data To File");
            if (!string.IsNullOrEmpty(errorMessage)) Console.WriteLine($"\n{errorMessage}\n");
            Console.Write("\nEnter the path to the sales data file: ");
            var filePath = Console.ReadLine();
            var salesData = GetSalesData();
            var error = false;
            if (File.Exists(filePath))
            {
                Console.Write("File exists. (O)verwrite or (A)ppend: ");
                var input = Console.ReadKey().Key;
                while (input != ConsoleKey.A && input != ConsoleKey.O)
                {
                    Console.Write("Enter 'O' or 'A': ");
                    input = Console.ReadKey().Key;
                }
                if (input == ConsoleKey.A)
                {
                    File.AppendAllText(filePath, salesData);
                }
                else
                {
                    File.WriteAllText(filePath, salesData);
                }
            }
            else
            {
                try
                {
                    File.WriteAllText(filePath, salesData);
                }
                catch
                {
                    error = true;
                }
            }
            if (error)
            {
                WriteSalesToFile($"Unable to write to file: {filePath}\nPlease try again.");
            }
            else
            {
                Console.WriteLine($"\nSuccessfully added sales data to file: {filePath}");
            }
        }
