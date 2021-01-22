    private void Form_Load(object sender, EventArgs e)
    {
        ControlHelper.AttachGotLostFocusEvents(
            this.Controls,
            new EventHandler(EditControl_GotFocus),
            new EventHandler(EditControl_LostFocus));
    }
    
    private void Form_Closed(object sender, EventArgs e)
    {
        ControlHelper.DetachGotLostFocusEvents(
            this.Controls,
            new EventHandler(EditControl_GotFocus),
            new EventHandler(EditControl_LostFocus));
    }
    
    private void EditControl_GotFocus(object sender, EventArgs e)
    {
        ShowKeyboard();
    }
    
    private void EditControl_LostFocus(object sender, EventArgs e)
    {
        HideKeyboard();
    }
