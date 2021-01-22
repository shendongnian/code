    public class EmployeeCollection : Collection<Employee>
    {
          public EmployeeCollection(IList<Employee> list) : base(list)
          {}
          public EmployeeCollection() : base()
          {}
        
    }
