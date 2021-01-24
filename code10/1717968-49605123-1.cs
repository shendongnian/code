    private void Form1_Load(object sender, EventArgs e)
    {
    	for(int idx = 0; idx < 5; idx++)
    	{
    		var gBox = new GroupBox();
    		gBox.Height = 50;
    		gBox.Width = 50;
    		gBox.Text = "Box: " + idx;
    		gBox.Tag = idx;
    
    		gBox.MouseClick += GBox_MouseClick;
    
    		this.Controls.Add(gBox);
    	}
    }
    
    private void GBox_MouseClick(object sender, MouseEventArgs e)
    {
    	//var ctrl = sender as Control; -- Not required
    	int questionIdx = (int)(sender as Control).Tag;            
    }
