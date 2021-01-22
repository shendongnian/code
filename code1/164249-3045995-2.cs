    private void EnableButtonVisibility( Button btn, bool enable, bool clearTag )    
    {     
        if ( !btn.InvokeRequired )    
        {    
    	btn.Visible = enable;    
        }   
        else    
        {    
            btn.Invoke( new EnableButtonVisibilityHandler( EnableButtonVisibility ), btn, enable, clearTag );    
        }    
    }    
