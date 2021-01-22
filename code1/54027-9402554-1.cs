    public static string GetAllItems<T>(...) where T : new()
    {
       ...
       List<T> tabListItems = new List<T>();
       foreach (ListItem listItem in listCollection) 
       {
            object[] args = new object[] { listItem };
            tabListItems.Add((T)Activator.CreateInstance(typeof(T), args)); // Now using Activator.CreateInstance
       } 
       ...
    }
