    static void Main(string[] args)
    {
        var store = new ContactYieldStore();
        var contacts = store.GetEnumerator();
        Console.WriteLine("Ready to iterate through the collection");
        Console.WriteLine("Hello {0}", contacts.First().FirstName);
        Console.ReadLine();
    }
