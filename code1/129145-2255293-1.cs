        List<string> temp = new List<string>();
        temp.Add("a");
        temp.Add("b");
        temp.Add("c");
        CommaDelimitedStringCollection cdsc = new CommaDelimitedStringCollection();
        cdsc.AddRange(temp.ToArray());
        Console.WriteLine(cdsc.ToString());
