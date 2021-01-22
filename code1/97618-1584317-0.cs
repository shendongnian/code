    bool canMove = false;
    
    private void Form1_Load(object sender, EventArgs e)
    {
    	canMove = true;
    }
    
    private void Form1_Move(object sender, EventArgs e)
    {
    	if (canMove)
    	{
    		this.Opacity = 0.5;
    	}
    }
    
    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
    	this.Opacity = 1;
    }
