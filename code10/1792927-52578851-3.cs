    private void button_one_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button is MouseButtons.Left)
        {
            button_one.ContextMenu = new ContextMenu();
            button_one.ContextMenu.Add("Copy", menu_item_copy_click);
    	    button_one.ContextMenu.Show(button_one, new Point(e.X, e.Y));
        }
    }
    private void menu_item_copy_click(object sender, EventArgs e)
    {
        // Do something here
    }
