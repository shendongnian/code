    public delegate void ButtonEventHandler();
    public event ButtonEventHandler ButtonEvent;
    protected void Button1_Click(object sender, EventArgs e)
    {
        ButtonEvent();
    }
