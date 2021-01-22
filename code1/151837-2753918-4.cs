    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string MiddleName { get; set; }
        public Employee(string firstName, string lastName,
                string qualification = "N/A", string middleName = "")
        {
            FirstName= firstName;
            LastName= lastName;
            Qualification= qualification;
            MiddleName = middleName;
        }
    }
