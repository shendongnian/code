    private void timer1_Tick(object sender, EventArgs e)
    {
    	// clear all the controls under panel
    	panel.Controls.Clear();
    	
    	// all your code to fetch the value from DB, and concatenate all
    	// required columns to make your desired value.
    	// set the label text as you value.
    	// add labels to panel
    	
    	panel.Controls.Add(txt);
    }
    
    System.Windows.Forms.Panel panel = null;
    private void Form3_Load(object sender, EventArgs e)
    {
        timer1.Start();
    	panel = new System.Windows.Forms.Panel();
    	this.Controls.Add(panel);
    }
