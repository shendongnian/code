        public class ContactListStore : IStore<ContactModel>
        {
            public IEnumerable<ContactModel> GetEnumerator()
            {
                var contacts = new List<ContactModel>();
                Console.WriteLine("ContactListStore: Creating contact 1");
                contacts.Add(new ContactModel() { FirstName = "Bob", LastName = "Blue" });
                Console.WriteLine("ContactListStore: Creating contact 2");
                contacts.Add(new ContactModel() { FirstName = "Jim", LastName = "Green" });
                Console.WriteLine("ContactListStore: Creating contact 3");
                contacts.Add(new ContactModel() { FirstName = "Susan", LastName = "Orange" });
                return contacts;
            }
        }
        
        static void Main(string[] args)
        {
            var store = new ContactListStore();
            var contacts = store.GetEnumerator();
         
            Console.WriteLine("Ready to iterate through the collection.");
            Console.ReadLine();
        }
    
