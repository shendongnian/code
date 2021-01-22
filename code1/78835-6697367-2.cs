    private void myform_Closing(object sender, FormClosingEventArgs e) 
    {
    	DialogResult dr = MessageBoxFarsi.Show("Do You Want to Save Data?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning)
    
    	if (dr == DialogResult.Cancel) 
    	{
    		e.Cancel = true;
            return;
    	}
    	else if (dr == DialogResult.Yes)
    	{
    		//TODO: Save
    	}
    }
    
    //now add a default constructor 
    public myform()  // here use your form name.
    {
    	this.FormClosing += new FormClosingEventHandler(myform_Closing); 
    }
