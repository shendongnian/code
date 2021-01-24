    if(listBox1.SelectedItems != null)
    {
        // Assuming its List of string
        var items = listBox1.DataSource as List<string>;  
     
        // Remove multiple selected items
        var count = listBox1.SelectedItems.Count;    
        while(count != 0)
        {
            var selectedItem = listBox1.SelectedItems[count-1];
            if(items.ContainsKey(selectedItem))
            {
                items.Remove(selectedItem);
            }
            count--;
        }
        listBox1.DataSource = null;
        listBox1.Items.Clear();
        listBox1.DataSource = items;
    }
