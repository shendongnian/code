    List<Employee> listA = new List<Employee>();
            List<Employee> listB = new List<Employee>();
            listA.Add(new Employee() { Id = 1, Name = "Bill" });
            listA.Add(new Employee() { Id = 2, Name = "Ted" });
            listB.Add(new Employee() { Id = 1, Name = "Bill Sr." });
            listB.Add(new Employee() { Id = 3, Name = "Jim" });
            var identicalQuery = from employeeA in listA
                                 join employeeB in listB on employeeA.Id equals employeeB.Id
                                 select new { EmployeeA = employeeA, EmployeeB = employeeB };
            foreach (var queryResult in identicalQuery)
            {
                Console.WriteLine(queryResult.EmployeeA.Name);
                Console.WriteLine(queryResult.EmployeeB.Name);
            }
