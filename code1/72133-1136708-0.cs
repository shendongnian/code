    private void Panel_MouseDown(object sender, MouseEventArgs e)
    {
         // make all mouse events being raised in the _aim panel
         // regardless of whether the mouse is within the control's
         // bounds or not
        _aim.Capture = true;
    }
    
    private void Panel_MouseMove(object sender, MouseEventArgs e)
    {
        if (_aim.Capture)
        {   
            // get the process id only if we have mouse capture 
            uint processId = GetProcessIdFromPoint(
                _aim.PointToScreen(e.Location)).ToString();
            // do something with processId (store it for remembering the 
            // last processId seen, to be used as MouseUp for instance)
        }
    }
    private void Panel_MouseUp(object sender, MouseEventArgs e)
    {
        if (_aim.Capture)
        {
            // release capture if we have it
            _aim.Capture = false;
            // perhaps do something more (fetch info about last seen
            // process id, if we stored it during MouseMove, for instance)
        }
    }
