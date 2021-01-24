    string WHOLE = "xxx,yyy,zzz";
    IEnumerable<string> list;
    list = WHOLE.Split(',');
    foreach(string l in list)
    {
        Console.WriteLine(l); 
    }
   
    // xxx
    // yyy
    // zzz
    // ...
