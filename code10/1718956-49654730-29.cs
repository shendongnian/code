        private static void DisplayEmployeeOfTheWeekInfo()
        {
            ClearAndWriteHeading("Car Dealership Sales Tracker - Employee of the Week");
            var employeeOfTheWeek = Employees
                .OrderByDescending(employee => employee.WeeklySales)
                .First();
            Console.WriteLine($"{employeeOfTheWeek} is the employee of the week!");
            Console.WriteLine(
                $"This person sold {employeeOfTheWeek.WeeklySales} cars this week.");
        }
