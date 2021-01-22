    public sealed class Name
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string middleName;
        // Consider changing the ordering here?
        public Name(string firstName, string lastName, string middleName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
        }
        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }
        public string MiddleName
        {
            get { return middleName; }
        }
    }
