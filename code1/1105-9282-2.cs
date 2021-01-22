    public void DoSomething()
    {
        if (Click != null) // Unnecessary! 
        {
            Click(this, "foo");
        }
    }
