    private List<ListItem> GetItems()
    {
      var items = new List<ListItem>();
      var collection = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      
      foreach (var i in collection)
      {
        items.Add(new ListItem { Text = i.ToString() });
      }
    
      return items;
    }
