    void SetupListView()
    {
    	listView.ItemCheck += new ItemCheckEventHandler(listView_ItemCheck);
    	listView.MouseDown += new MouseEventHandler(listView_MouseDown);
    	listView.MouseUp += new MouseEventHandler(listView_MouseUp);
    	listView.MouseLeave += new EventHandler(listView_MouseLeave);
    }
    bool mouseDown = false;
    void listView_MouseLeave(object sender, EventArgs e)
    {
    	mouseDown = false;
    }
    void listView_MouseUp(object sender, MouseEventArgs e)
    {
    	mouseDown = false;
    }
    void listView_MouseDown(object sender, MouseEventArgs e)
    {
    	mouseDown = true;
    }
    void listView_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if(mouseDown)
        {
        	e.NewValue = e.CurrentValue;
        }
    }
