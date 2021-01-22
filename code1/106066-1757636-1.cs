    private void BuildMenuItems()
    {
        ToolStripMenuItem[] items = new ToolStripMenuItem[2]; // You would obviously calculate this value at runtime
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new ToolStripMenuItem();
            items[i].Name = "dynamicItem" + i.ToString();
            items[i].Tag = "specialDataHere";
            items[i].Text = "Visible Menu Text Here";    
            items[i].Click += new EventHandler(MenuItemClickHandler);
        }
        
        myMenu.DropDownItems.AddRange(items);
    }
    private void MenuItemClickHandler(object sender, EventArgs e)
    {
        ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
        // Take some action based on the data in clickedItem
    }
