    string[] items = new string[] {"Uno","Dos","Tres"};
    
    for (int i = 0; i < items.Length; i++)
        items[i] = Convert.ToBase64String(Encoding.UTF8.GetBytes(items[i]));
    
    string toEncrypt = String.Join("|", items);
    
    items = toEncrypt.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
    
    foreach (string s in items)
         Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(s)));
