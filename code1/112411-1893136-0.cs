        char specialChar = (char)10781;
                
        string specialString = Convert.ToString(specialChar);
        // prints 1
        Console.WriteLine(specialString.Length);
        // prints 10781
        Console.WriteLine((int)specialChar);
        // prints false
        Console.WriteLine(string.Empty.StartsWith("A"));
        // prints false
        Console.WriteLine(string.Empty.StartsWith(specialString, StringComparison.Ordinal));
