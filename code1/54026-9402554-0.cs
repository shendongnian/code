    public static string GetAllItems<T>(...) where T : new()
    {
       ...
       List<T> tabListItems = new List<T>();
       foreach (ListItem listItem in listCollection) 
       {
           tabListItems.Add(new T() { YourPropertyName = listItem } ); // Now using object initializer
       } 
       ...
    }
