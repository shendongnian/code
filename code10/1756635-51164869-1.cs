    var employees = context.Employees.Where(e => 
                          e.Department.Name == "Engineering" || 
                          e.Department.Name == "Tool Design" || 
                          e.Department.Name == "Marketing" || 
                          e.Department.Name == "Information Services");
    
    // you need to modify each employee
    foreach(var employee in employees)
    {   
         // not sure this is correct, add pepper and salt to taste 
         employee.Salary = employee.Salary * 12 / 100 + e.Salary;
    }
    
    // then you can save
    context.SaveChanges();
    
    // List of infos
    var listofInfo =  employees.OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:F2})")
                        .ToList();
    
    foreach(var item in listofInfo)
       Console.WriteLine(item);
