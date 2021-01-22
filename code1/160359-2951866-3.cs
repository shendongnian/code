    public void RegisterFunction(EventHandler func)
    {
        foreach (Control c in Controls)
        {
             c.Click += func;
        }
    }
