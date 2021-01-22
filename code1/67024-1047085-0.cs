    public event EventHandler AnEvent;
    
    public OtherClass Inner {
        get { /* ... */ }
        set {
            if(Inner != null)
                Inner.AnEvent -= Inner_AnEvent;
            //...
            if(value != null)
                value.AnEvent += Inner_AnEvent;
            //...
        }
    }
    
    void Inner_AnEvent(object sender, EventArgs e) { 
        var handler = AnEvent;
        if (handler != null) handler(sender, e);
    }
