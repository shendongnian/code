        private static void GenerateSalesData()
        {
            ClearAndWriteHeading("Car Dealership Sales Tracker - Generate Sales Data");
            foreach (var employee in Employees)
            {
                employee.WeeklySales = Rnd.Next(50, 201);
            }
            Console.WriteLine("\nSales data has been generated!!");
        }
