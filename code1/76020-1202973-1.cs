    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
 
        public static Employee Create(IDataRecord record)
        {
            return new Employee
            {
               Id = record["id"];
               Name = record["name"];
            };
        }
    }
.
    public function GetEmployees()
    {
        using (var rdr = YourLibraryFunction())
        {
           while (rdr.Read())
           {
               yield return Employee.Create(rdr);
           }
        }
    }
