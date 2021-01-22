    private void MainForm_Load(object sender, EventArgs e)
    {
    	splitContainerControl.Paint += new PaintEventHandler(splitContainerControl_Paint);
    }
    
    void splitContainerControl_Paint(object sender, PaintEventArgs e)
    {
    	splitContainerControl.Paint -= splitContainerControl_Paint;
    	// Handle restoration here
    }
