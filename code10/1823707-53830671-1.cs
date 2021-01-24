    public class Person
    {
        private string FirstName { get; set {if(value == null) FirstName } = string.Empty;
        private string MiddleName { get; set; } = string.Empty;
        string LastName { get; set; } = string.Empty;
        int Age { get; set; }
        public string getName()
        {
            // Here handle the null case
        }
    }
