        //declare
        List<Object> items = new List<Object>();
        for (int i = 0; i < from.SelectedItems.Count; i++)
        {
            items.Add(from.SelectedItems[i]);
        }
        for (int i = 0; i < items.Count; i++)
        {
            to.Items.Add(items[i].ToString());
            from.Items.Remove(items[i]);
        }
        
