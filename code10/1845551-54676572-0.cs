    public interface ISsn
    {
        string Ssn { get; set; }
    }
    public interface IManagerOf
    {
        List<Employee> Manages { get; set; }
    }
    
    public class Ssn : ISsn { ... }
    public class ManagerOf : IManagerOf { ... }
    
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
    
    // here we are implementing the interfaces on the class, but you could just expose each interface as a property
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
        // ... or expose each interface:
        public ISsn Ssn => _ssn;
        public IManagerOf ManagerOf => _managerOf;
    }
