    String[] strings = new String[] { "1", "2", "3", "4", "2", "5", "4", "6", "7" };
    StringCollection unique = new StringCollection();
    
    foreach (String s in strings)
    {
         if (!unique.Contains(s))
             unique.Add(s);
    }
    
    foreach (String s in unique)
    {
         Console.WriteLine(s);
    }
