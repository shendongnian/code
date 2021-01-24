    public class Person
    {
        public Contact Contact { get; set; }
    }
    public class Contact
    {
        public Email Email { get; set; }
    }
    public class Email { public string EmailAddress { get; set; } }
