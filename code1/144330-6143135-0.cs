    //Make a menu strip
    MenuStrip menu = new MenuStrip();
    this.Controls.Add(menu);
    
    //Add category "File"
    ToolStripMenuItem fileItem = new ToolStripMenuItem("File");
    menu.Items.Add(fileItem);
    
    this.toolTip = new ToolTip();
    this.toolTip.AutoPopDelay = 0;
    this.toolTip.AutomaticDelay = 0;
    this.toolTip.UseAnimation = true;
    
    //Add items
    for (int i = 0; i < 10; i++)
    {
    	ToolStripMenuItem item = new ToolStripMenuItem("item");
    	
    	//disable the default tool tip of ToolStripMenuItem
    	item.AutoToolTip = false;
    		
    	//instead, use Tooltip class to show to text when mouse hovers the item
    	item.MouseHover += new EventHandler(item_MouseHover);
    	item.DropDownItems.Add("sub item");
    
    	fileItem.DropDownItems.Add(item);
    }
    	
    void item_MouseHover(object sender, EventArgs e)
    {
    	ToolStripMenuItem mItem = (ToolStripMenuItem)sender;
    	toolTip.Show("tool tip", mItem.Owner, 1500);
    }
