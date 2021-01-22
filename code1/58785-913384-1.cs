    protected void Page_Load(object sender, EventArgs e)
    {
        var myObj = new MyClass();
        myObj.MyEvent += new EventHandler(this.HandleCustomEvent);
    }
    
    private void HandleCustomEvent(object sender, EventArgs e)
    {
        // handle the event
    }
