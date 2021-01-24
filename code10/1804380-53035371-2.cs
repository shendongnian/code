    var panels = this.Controls
    	.Cast<Control>()
    	.Where(c => c != MyPanel && c is Panel);
    
    foreach (var c in panels)
    {
    	c.Visible = false;
    }
