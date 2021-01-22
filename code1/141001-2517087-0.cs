    foreach (var special in new string[] { @"\n", @"\t", @"\r\n" })
    {
        Console.WriteLine("|{0}|", special);
        Console.WriteLine("|{0}|", Regex.Unescape(special));
        Console.WriteLine("----------------------"); 
    }
