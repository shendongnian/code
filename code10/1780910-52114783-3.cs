    DirectoryEntry myDirectoryEntry = new DirectoryEntry();
        // Display the 'SchemaClassName'.
        Console.WriteLine("Schema class name:" + myDirectoryEntry.SchemaClassName);
        // Gets the SchemaEntry of the ADS object.
        DirectoryEntry mySchemaEntry = myDirectoryEntry.SchemaEntry;
        if (string.Compare(mySchemaEntry.Name, "domainDNS") == 0)
        {
            foreach (DirectoryEntry myChildDirectoryEntry in myDirectoryEntry.Children)
                Console.WriteLine(myChildDirectoryEntry.Path);
        }
        Console.ReadLine();
    
