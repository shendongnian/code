    public void DoSomething()
    {
        // Unnecessary!
        MyClickHandler click = Click;
        if (click != null) // Unnecessary! 
        {
            click(this, "foo");
        }
    }
