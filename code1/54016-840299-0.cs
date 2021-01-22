    public static string GetAllItems<T>(..., Func<ListItem,T> del) {
      ...
      List<T> tabListItems = new List<T>();
      foreach (ListItem listItem in listCollection) 
      {
        tabListItems.Add(del(listItem));
      }
      ...
    }
