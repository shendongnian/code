    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
 
        public static Employee Create(IDataRecord record)
        {
            return new Employee
            {
               Id = record["id"],
               Name = record["name"]
            };
        }
    }
.
    public IEnumerable<Employee> GetEmployees()
    {
        using (var reader = YourLibraryFunction())
        {
           while (reader.Read())
           {
               yield return Employee.Create(reader);
           }
        }
    }
