    public delegate void OnButtonClick(object sender, EventArgs e);
    public event OnButtonClick Button1Click;
    button1_click(object sender, EventArgs e)
    {
        if(Button1Click != null) 
           Button1Click(this, e);
    }
