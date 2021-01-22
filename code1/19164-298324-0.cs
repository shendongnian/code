        System.Collections.Specialized.NameValueCollection k = 
            new System.Collections.Specialized.NameValueCollection();
        k.Add("B", "Brown");
        k.Add("G", "Green");
        Console.WriteLine(k[0]);    // Writes Brown
        Console.WriteLine(k["G"]);  // Writes Green
