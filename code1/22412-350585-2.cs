       public class Division
        {
            private int divId;
            public int DivisionId { get; set; }
    
            private Collection<Employee> emps;
            public Collection<Employee> Employees
            { get { return emps ?? (emps = new Employee(DivisionId)); } }
        }
