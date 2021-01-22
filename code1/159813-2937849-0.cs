    public class Employee
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string AddressCollection { get; set; }
    }
    
    public class EmployeeCollection<T> : List<T> where T : Employee
    {
      public bool Add(T Data)
      {
        return this.Add(Data);
      }
    }
