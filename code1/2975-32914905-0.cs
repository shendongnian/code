    public class AddressBook
    {
        private readonly List<Contact> contacts;
    
        public AddressBook()
        {
            this.contacts = new List<Contact>();
        }
    
        public IReadOnlyList<Contact> Contacts { get { return contacts; } }
    
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
    
        public void RemoveContact(Contact contact)
        {
            contacts.Remove(contact);
        }
    }
