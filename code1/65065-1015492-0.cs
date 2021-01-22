    List<string> list1 = new List<string>();
    list1.Add("Blah");
    list1.Add("Bleh");
    list1.Add("Blih");
    
    List<string> list2 = new List<string>();
    list2.Add("Ooga");
    list2.Add("Booga");
    list2.Add("Wooga");
    
    var finalList = list1.Concat( list2 ).ToList();
