    protected override void Dispose(bool disposing)
    {
    	
    	if (disposing)
    	{
    		var overflow = toolStrip1.OverflowButton.DropDown as ToolStripOverflow;
    		if (overflow != null)
    			overflow.Dispose();
    	}
    	
    
    	if (disposing && (components != null))
    	{
    		components.Dispose();
    	}
    	base.Dispose(disposing);
    }
