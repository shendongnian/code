    public ToolTip tT { get; set; }
    
    public ClassConstructor()
    {
        tT = new ToolTip();
    }
    
    private void MyControl_MouseHover(object sender, EventArgs e)
    {
        tT.Show("Why So Many Times?", this);
    }
