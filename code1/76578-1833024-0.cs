    List<string> list = new List<string>();
    
    list.Add("Hello");
    list.Add("Who");
    list.Add("Are");
    list.Add("You");
    
    foreach (String s in list)
    {
        Console.WriteLine(list[list.Count - list.IndexOf(s) - 1]);
    }
