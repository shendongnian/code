    List<string> l = new List<string>();
    l.Add("astring");
    
    //example 1
    IEnumerator e1 = l.GetEnumerator();
    if (e1.MoveNext())
        Console.WriteLine(e1.Current);
    
    //example 2
    if (l.Count != 0)
        Console.WriteLine(l.Single());
