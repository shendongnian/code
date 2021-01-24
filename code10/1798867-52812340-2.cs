    var  contacts=JsonConvert.DeserializeObject<Contact[]>(contactValue);
    //Iterate over the results
    foreach(var contact in contacts)
    {
        Console.WriteLine(contact.name);
    }
    //Or use LINQ
    var names=contacts.Select(it=>it.name).ToList();
