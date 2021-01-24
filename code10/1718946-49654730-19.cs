        private static string GetSalesData()
        {
            var data = new StringBuilder();
            data.AppendLine("Employee".PadRight(25) + "Sales");
            data.AppendLine(new string('-', 30));
            foreach (var employee in Employees)
            {
                data.AppendLine(employee.FirstName.PadRight(25) + employee.WeeklySales);
            }
            data.AppendLine(new string('-', 30));
            data.AppendLine("Total".PadRight(25) + 
                Employees.Sum(employee => employee.WeeklySales));
            return data.ToString();
        }
