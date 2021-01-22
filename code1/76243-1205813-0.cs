    List<string> newList = new List<string>();
    
    foreach (string s in list)
    {
       if (!newList.Contains(s))
          newList.Add(s);
    }
    
    // newList contains the unique values
