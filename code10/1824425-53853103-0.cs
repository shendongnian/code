    var list = new List<Person>
    {
        new Person
        {
            Contact = new Contact { Email = new Email () }
        },
        new Person { Contact = null }
    };
    /*
        * This is okay, since the linq expression hasn't been evaluated.
        * It is still simply a LINQ Query in memory. It will remain 'just
        * a LINQ Query' until the result is used.
        */
    var result = list.Select(person => person.Contact.Email);
    /*
        * This will cause the NullReferenceException, because the ToList() call
        * will cause the Linq Query to be evaulated. Upon evaluating the expression 
        * the person with the null contact will be iterated over.
        */
    var result2 = list.Select(person => person.Contact.Email).ToList();
    /*
        * Here is a solution for you. Filter out the instances of null contacts from
        * the initial list.
        */
    var result3 = list.Where(person => person.Contact != null).Select(person => person.Contact.Email).ToList();
    /*
        * This might be your solution. The Null Propagation operator '?.' was introduced in .NET 4.6.
        * It will conditionally check for nulls in line. If a nul is found in a statement,
        * the code will shortcut and return null. Then with the Null Coalescing operator '??', 
        * you can handle the absence of the contact however you wish.
        */
    var result4 = list.Select(person => person.Contact?.Email ?? new Email()).ToList();
