    public void DoSomething()
    {
        if (Click != null) // Unnessecary!
        {
            Click(this, "foo");
        }
    }
