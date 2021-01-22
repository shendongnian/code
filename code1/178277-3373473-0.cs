    //This make sense
    public class Person {
    
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
        public Address Address { get; set; }
        public PhoneNumber[] ContactNumbers { get; set; }
    }
    
    //This does not make as much sense, but it's still possible.
    public class Person {
        public Name Name { get; set; }
        public Address Address { get; set; }
        public PhoneNumber[] ContactNumbers { get; set; }
    }
