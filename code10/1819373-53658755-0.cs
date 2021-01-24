         List<Employee> empListJoe = new List<Employee>();
         foreach (Employee employee in empList)
         {
            if (employee.FName == "Joe")
            {
               empListJoe.Add(employee);
            }
         }
         foreach (Employee employeee in empListJoe)
         {
            Console.WriteLine($"{employeee.FName} {employeee.LName}");
         }
         Console.ReadLine();
