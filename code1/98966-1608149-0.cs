    void AddMenuItem(string text, string action)
    {
       MenuItem item = new MenuItem();
       item.Text = text;
       item.Tag = action;
       item.Click += new EventHandler(someHistoryMenuItem_Click);
    
       historyMenu.Items.Add(item);
    }
    private void someHistoryMenuItem_Click(object sender, EventArgs e)
    {
       MenuItem menuItem = sender as MenuItem;
    
       string args = menuItem.Tag.ToString();
    
       YourSpecialAction(args);
    }
