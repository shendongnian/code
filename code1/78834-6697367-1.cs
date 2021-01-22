    Private void clossingmyform( object sender, Formclossingeventargs e ) 
    {
    	DialogResult dr =MessageBoxFarsi.Show("Do You Want to Save Data?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning)
    
    	if ( dr.Dilogresult == yes ) 
    	{
    		e.Cancelt = false ; 
    
    	}
    	else if ( dr.Dilogresult == Dilogresult.Cancel )
    	{
    		e.cancel = true ; 
    	}
    
    } 
    
    now add a default constructor 
    
    public myform()  // here use your form name.
    {
    	this.Formclosing += new Formclosingevenhandler (clossingmyform); 
    }
