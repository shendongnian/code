    private void RemoveMenuItem(string itemText, Menu menu)
    {
       foreach (MenuItem menuItem in menu.Items)
       {
          if (menuItem.Text.Equals(itemText, StringComparison.CurrentCultureIgnoreCase))
          {
               menu.Items.Remove(menuItem);
               break;
          }
            
          bool found = false;
            
          if (menuItem.ChildItems.Count > 0) RemoveChildMenuItem(itemText, menuItem, out found);
            
          if (found) break;
        }
    }
        
    private void RemoveChildMenuItem(string itemText, MenuItem mi, out bool Found)
    {
          Found = false;
       
          foreach(MenuItem menuItem in mi.ChildItems)
          {
             if (menuItem.Text.Equals(itemText, StringComparison.CurrentCultureIgnoreCase))
            {
                mi.ChildItems.Remove(menuItem);
                Found = true;
                break;
            }                
         }
    }
