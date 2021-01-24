        private static void ProcessMenuItem(int itemNumber)
        {
            switch (itemNumber)
            {
                case 1:
                    DisplayEmployeeOfTheWeekInfo();
                    break;
                case 2:
                    DisplayTotalSales();
                    break;
                case 3:
                    WriteSalesToFile();
                    break;
                case 4:
                    GenerateSalesData();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            Console.Write("\nPress any key to go back to main menu...");
            Console.ReadKey();
            MainMenu();
        }
