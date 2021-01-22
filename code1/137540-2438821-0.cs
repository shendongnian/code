    private void CopySelItems(ListBox from, ListBox to)
        {
            for (int i = 0; i < from.SelectedItems.Count; i++)
            {
                to.Items.Add(from.SelectedItems[i].ToString());
            }
          
        }
