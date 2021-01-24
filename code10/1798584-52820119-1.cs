	Console.WriteLine("1");
    Task<Contact> getContactTask = GetContact();
    Console.WriteLine("2");
    Contact contact = await getContactTask; // the code is now executed
    Console.WriteLine("4");
