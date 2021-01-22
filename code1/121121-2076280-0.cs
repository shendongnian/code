    //save the winform position and size upon closing
    private void Form1_FormClosed(
       object sender, FormClosedEventArgs e)
    {
    	Properties.Settings.Default.FormPosition = this.Location;
    	Properties.Settings.Default.FormSize = this.Size;
    	Properties.Settings.Default.Save();
    }
    
    //load the winform position and size upon loading
    private void Form1_Load(object sender, EventArgs e)
    {
    	this.Size = Properties.Settings.Default.FormSize;
    	this.Location = Properties.Settings.Default.FormPosition;
    }
 
