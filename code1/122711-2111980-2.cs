    List<WebControl> yourControls = new List<WebControl>();
    //...
    
    protected void Page_Load(object sender, EventArgs e)
    {
        yourControls.Add(txt1);
        yourControls.Add(txt2);
        // and so on... 
    }
