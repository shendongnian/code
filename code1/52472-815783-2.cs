    string[] items = new string[] {"Uno","Dos","Tres"};
    
    string toEncrypt = String.Join("|", items);
    
    items = toEncrypt.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
    
    foreach(string s in items)
      Console.WriteLine(s);
