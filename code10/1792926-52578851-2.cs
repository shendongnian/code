    private void button_one_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button is MouseButtons.Left)
        {
            button_one.ContextMenu = new ContextMenu();
            button_one.ContextMenu.Add("Copy");
            button_one.ContextMenu.Items[0].Click += MenuItem_Click;
    	    button_one.ContextMenu.Show(button_one, new Point(e.X, e.Y));
        }
    }
    private void MenuItem_Click(object sender, EventArgs e)
    {
        // Do something here
    }
