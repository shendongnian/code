    void AddMenuItem(string text, string action)
    {
       ToolStripMenuItem item = new ToolStripMenuItem();
       item.Text = text;
       item.Click += new EventHandler(item_Click);
       item.Tag = action;
    
       //first option, inserts at the top
       //historyMenu.Items.Add(item);
       //second option, should insert at the end
       historyMenuItem.DropDownItems.Insert(historyMenuItem.DropDownItems.Count, item);
    }
    private void someHistoryMenuItem_Click(object sender, EventArgs e)
    {
       ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
    
       string args = menuItem.Tag.ToString();
    
       YourSpecialAction(args);
    }
