    //and to print all values
    foreach(string code in data.Keys)
    {
        Console.WriteLine("For Code: " + code);
        foreach(string value in data[code].ContactSp)
        {
            Console.WriteLine("     " + value);
        }
    }
