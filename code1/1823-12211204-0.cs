    try this  **USE ORDER BY** :
    
       public class Employee
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    
     private static IList<Employee> GetItems()
            {
                List<Employee> lst = new List<Employee>();
    
                lst.Add(new Employee { Id = "1", Name = "Emp1" });
                lst.Add(new Employee { Id = "2", Name = "Emp2" });
                lst.Add(new Employee { Id = "7", Name = "Emp7" });
                lst.Add(new Employee { Id = "4", Name = "Emp4" });
                lst.Add(new Employee { Id = "5", Name = "Emp5" });
                lst.Add(new Employee { Id = "6", Name = "Emp6" });
                lst.Add(new Employee { Id = "3", Name = "Emp3" });
    
                return lst;
            }
    
    **var lst = GetItems().AsEnumerable();
    
                var orderedLst = lst.OrderBy(t => t.Id).ToList();
    
                orderedLst.ForEach(emp => Console.WriteLine("Id - {0} Name -{1}", emp.Id, emp.Name));**
