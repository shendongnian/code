    int encryptedEntries = 0;
    using (var zip = ZipFile.Read(nameOfZipFile)) 
    {
        // check a specific, named entry: 
        if (zip["nameOfEntry.doc"].UsesEncryption)
           Console.WriteLine("Entry 'nameOfEntry.doc' uses encryption"); 
        // check all entries: 
        foreach (var e in zip)
        {
           if (e.UsesEncryption)
           {
               Console.WriteLine("Entry {0} uses encryption", e.FileName); 
               encryptedEntries++; 
           }
        }
    }
    if (encryptedEntries > 0) 
        Console.WriteLine("That zip file uses encryption on {0} entrie(s)", encryptedEntries); 
