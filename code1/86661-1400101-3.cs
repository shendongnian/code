    public delegate void CloseButtonHandler();
    public event CloseButtonHandler CloseButtonEvent;
     
    protected void btnClose_Click(object sender, EventArgs e)
    {
        CloseButtonEvent();
    }
