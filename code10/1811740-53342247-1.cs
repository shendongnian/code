    public class ContactWithEmail : IContactWithEmail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ContactWithEmail(IContact contact, string email)
        {
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            Email = email;
        }
    }
