    List<string> theList = new List<string>();
    theList.Add("The name");
    theList.Add(null);
    theList.Add("stree1 line 1");
    theList.Add(null);
    theList.Add("postal town");
    theList.Add("postal code");
    theList.Add(null);
    Console.WriteLine(string.Join(":", theList.Where(l => !string.IsNullOrEmpty(l))))
