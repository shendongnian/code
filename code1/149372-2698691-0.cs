    dynamic foo = new ExpandoObject();
    
    // mimic grabbing a column name at runtime and adding it as a property
    ((IDictionary<string, object>)foo).Add("Name", "Apple");
    
    Console.WriteLine(foo.Name); // writes Apple to screen
