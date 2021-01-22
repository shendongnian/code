    public TestForm()
    {
        Button b = new Button();
    
        this.Controls.Add(b);
    
        MethodInfo method = typeof(TestForm).GetMethod("Clickbutton",
        BindingFlags.NonPublic | BindingFlags.Instance);
        Type type = typeof(EventHandler);
    
        Delegate handler = Delegate.CreateDelegate(type, this, method);
    
        EventInfo eventInfo = cbo.GetType().GetEvent("Click");
    
        eventInfo.AddEventHandler(b, handler);
    
    }
    
    void Clickbutton(object sender, System.EventArgs e)
    {
        // Code here
    }
