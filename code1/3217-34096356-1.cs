    public class ContactYieldStore : IStore<ContactModel>
    {
        public IEnumerable<ContactModel> GetEnumerator()
        {
            Console.WriteLine("ContactYieldStore: Creating contact 1");
            yield return new ContactModel() { FirstName = "Bob", LastName = "Blue" };
            Console.WriteLine("ContactYieldStore: Creating contact 2");
            yield return new ContactModel() { FirstName = "Jim", LastName = "Green" };
            Console.WriteLine("ContactYieldStore: Creating contact 3");
            yield return new ContactModel() { FirstName = "Susan", LastName = "Orange" };
        }
    }
     
    static void Main(string[] args)
    {
        var store = new ContactYieldStore();
        var contacts = store.GetEnumerator();
     
        Console.WriteLine("Ready to iterate through the collection.");
        Console.ReadLine();
    }
