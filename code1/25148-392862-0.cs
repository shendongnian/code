    //--Main form's OnLoad method
    protected override void OnLoad(EventArgs ea)
    {
        // Remember to call base implementation
        base.OnLoad(ea);
    
    	using( frmLogin frm = new frmLogin() )
    	{
    		if( frm.ShowDialog() != DialogResult.OK )
    		{
    			//--login failed - exit the application
    			Application.Exit();
    		}
    	}    	
    }
