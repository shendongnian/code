    // here we are implementing the interfaces on the class
    public class Employee : ISsn
    {
        private ISsn _ssn;
    
        public Employee(ISsn ssn)
        {
            _ssn = ssn;
        }
    
        public string Ssn
        {
            get { return _ssn.Ssn; }
            set { _ssn.Ssn = value }
        }
    }
    
    public class Manager : ISsn, IManagerOf
    {
        private ISsn _ssn;
        private IManagerOf _managerOf;
    
        public Employee(ISsn ssn, IManagerOf managerOf)
        {
            _ssn = ssn;
            _managerOf = managerOf;
        }
    
        public string Ssn
        {
            get { return _ssn.Ssn; }
            set { _ssn.Ssn = value }
        }
    
        public List<Employee> Manages
        {
            get { return _managerOf.Manages; }
            set { _managerOf.Manages = value; }
        }
    }
