      public IList<string> SelectedItems{
           get {
              return checkbox1.Items.Cast<ListItem>.Where(i => i.Selected).Select(j => j.Value).ToList();
           }
        
        }
