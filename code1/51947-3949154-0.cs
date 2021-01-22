       public void RemoveSelectedItems(ListBox listbox)
       {
           List<ListItem> items = GetSelectedItems(listbox);
           foreach (var listItem in items)
           {
               listbox.Items.Remove(listItem);
           }
       }
      public List<ListItem> GetSelectedItems(ListBox listbox)
      {
         int[] selectedIndices = listbox.GetSelectedIndices();
         return selectedIndices.Select(index => listbox.Items[index]).ToList();
      }
