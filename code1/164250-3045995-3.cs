    private void EnableButtonVisibility( Button btn, bool enable)    
    {     
        if ( !btn.InvokeRequired )    
        {    
     btn.Visible = enable;    
        }   
        else    
        {    
            btn.Invoke( new EnableButtonVisibilityHandler( EnableButtonVisibility ), btn, enable );    
        }    
    }    
    delegate void EnableButtonVisibilityHandler( Button btn, bool enable);
