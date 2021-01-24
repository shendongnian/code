    public class EmployeeCollection<Employee> : Collection<Employee>
    {
        public int EmpId;
        public string EmpName;
        public EmployeeCollection()
        {
            EmpId = 1;
            EmpName = "EmployeeCollection1";
        }
    }
    
    // serialize/deserialize
    using AnySerializer;
    
    var collection = new EmployeeCollection();
    var bytes = Serializer.Serialize(collection);
    var restoredCollection = Serializer.Deserialize<EmployeeCollection<Employee>>(bytes);
