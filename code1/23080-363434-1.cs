    List<string> l = new List<string>();
    l.Add("astring");
    
    ICollection col1 = (ICollection)l;
    ICollection<string> col2 = (ICollection<string>)l;
    
    //example 1
    IEnumerator e1 = col1.GetEnumerator();
    if (e1.MoveNext())
        Console.WriteLine(e1.Current);
    
    //example 2
    if (col2.Count != 0)
        Console.WriteLine(col2.Single());
