    private Panel container;
    
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get the item panel associated with the current selection.
        Panel itemPanel = GetItemPanelFromSelection(); 
        
        container.Controls.Clear();
        container.Controls.Add(itemPanel);
        itemPanel.Dock = DockStyle.Fill;
    }
