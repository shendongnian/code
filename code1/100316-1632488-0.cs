      private List<ListItem> GetItems()
        {
            var collection = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var items = new List<ListItem>(collection.Count);  //declare the amount of space here
    
            foreach (var i in collection)
            {
                ListItem item = new ListItem { Text = i.ToString() };
                items.Add(item);
            }
    
            return items;
        }
