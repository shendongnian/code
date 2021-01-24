    if (System.Windows.Forms.Screen.AllScreens.Length > 1)
    {
    	System.Drawing.Rectangle entireSize = System.Drawing.Rectangle.Empty;
    	
    	foreach (System.Windows.Forms.Screen s in System.Windows.Forms.Screen.AllScreens)
    		entireSize = System.Drawing.Rectangle.Union(entireSize, s.Bounds);
    
    	//this.WindowState = NORMAL // SET Window State to Normal.
    		
    		
    	this.Width = entireSize.Width;
    	this.Height = entireSize.Height;
    
    	this.Left = entireSize.Left;
    	this.Top = entireSize.Top;
    
    }
