    class Customer
    {
        public string FirstName { get; set ; }        
        public string LastName { get; set ; }
        public string GetFullName()
        {
            return FirstName + " " + LastName;   //Would be silly to pass in the first and last names here
        }
    }
