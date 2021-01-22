    // change some properties (for selection) and subscribe the ItemActivate 
    // event of the listView
    listView.HotTracking = true;
    listView.Activation = ItemActivation.OneClick;
    listView.ItemActivate += new EventHandler(listView_ItemActivate);
    
    
    // the click on the item invokes this method
    void listView_ItemActivate(object sender, EventArgs e)
    {
        var listview = sender as ListView;
        var item = listview.SelectedItems[0].ToString();
        var dropdown = listview.Parent as ToolStripDropDown;
        // unsubscribe the event (to avoid memory leaks)
        listview.SelectedIndexChanged -= listView_ItemActivate;
        // close the dropdown (if you want)
        dropdown.Close();
    
        // do whatever you want with the item
        MessageBox.Show("Item selected is: " + item);
    }
