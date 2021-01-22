Introduced a third entity called WellKnownContact and corresponding WellKnownContactType enum:
    public class Company
    {
        public string Name { get; set; }
        public IList<Employee> Employees { get; private set; }
        private IList<WellKnownEmployee> WellKnownEmployees { get; private set; }
        public Employee ContactPerson
        {
            get
            {
                return WellKnownEmployees.SingleOrDefault(x => x.Type == WellKnownEmployeeType.ContactPerson);
            }
            set
            {                
                if (ContactPerson != null) 
                {
                    // Remove existing WellKnownContact of type ContactPerson
                }
                // Add new WellKnownContact of type ContactPerson
            }
        }
    }
    public class Employee
    {
        public Company EmployedBy { get; set; }
        public string FullName { get; set; }
    }
    public class WellKnownEmployee
    {
        public Company Company { get; set; }
        public Employee Employee { get; set; }
        public WellKnownEmployeeType Type { get; set; }
    }
    public enum WellKnownEmployeeType
    {
        Uninitialised,
        ContactPerson
    }
