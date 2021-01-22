    // Initializes a new hashtable    
    Hashtable hTable = new Hashtable();
        
    // Adds an item to the hashtable
    hTable.Add("Name",  "Jon");
        
    // Loop through all the values in the hashtable
    IDictionaryEnumerator enumHtable = hTable.GetEnumerator();
    while (enumHtable.MoveNext())
    {
        string str = enumHtable.Value.ToString();
    }
