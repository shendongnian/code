    var List1 = new List<string>() { "a", "b", "c", "d" };
    var List2 = new List<string>() { "a", "e", "f", "g", "c","z" };
    var List3 = new List<string>();
    
    List3.AddRange(List1.Except(List2));
    List3.AddRange(List2.Except(List1));
    
    List3.ForEach(l=>Console.WriteLine(l));
