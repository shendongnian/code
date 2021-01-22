    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string MiddleName { get; set; }
        public Employee(string firstName, string lastName)
        {
            FirstName= firstName;
            LastName= lastName;
            Qualification= "N/A";
            MiddleName= string.Empty;
        }
        public Employee(string firstName, string lastName, string qualification)
        {
            FirstName= firstName;
            LastName= lastName;
            Qualification= qualification;
            MiddleName= string.Empty;
        }
        public Employee(string firstName, string lastName, string qualification,
            string middleName)
        {
            FirstName= firstName;
            LastName= lastName;
            Qualification= qualification;
            MiddleName= middleName
        }
    }
