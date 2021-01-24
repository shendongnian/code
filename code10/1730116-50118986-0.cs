    var list = new List<string>();
    list.Add("AAA");
    list.Add("AAAAA");
    list.Add("A");
    list.Add("AAAA");
    list.Add("AAAAAA");
    list.Add("AA");
    // Get maximum length 
    int maxlen = list.Max((item) => item.Length);
    // Find first string with that length
    string max = list.First((item) => item.Length==maxlen);
     
