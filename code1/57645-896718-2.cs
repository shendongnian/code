    public class Group
    {
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
    }
    public class Contact
    {
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
