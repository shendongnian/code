    Dictionary<int, string> myDictionary = new Dictionary<int, string>();
    
    myDictionary.Add(1, "string");
    myDictionary.Add(2, "string2");
    myDictionary.Add(4, "string4");
    
    mycb.DataSource = myDictionary.ToArray();
    
    mycb.DisplayMember = "Value";
    mycb.ValueMember = "Key";
