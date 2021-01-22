    //EventHandler declaration
    public event EventHandler  DataLoaded;
    protected void Mag_Button_Load_Click(object sender, EventArgs e)
    {
    
        //Raise Event
    	if (DataLoaded != null) {
    		DataLoaded(this, EventArgs.Empty);
    	}
    }
