    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Left)
    	{
    		var cm = new ContextMenu();
    		cm.MenuItems.Add("Menu Item 1");
    		cm.MenuItems.Add("Menu Item 2");
    
    		button1.ContextMenu = cm;
    		button1.ContextMenu.Show(button1, new Point(e.X, e.Y));
    	}
    }
