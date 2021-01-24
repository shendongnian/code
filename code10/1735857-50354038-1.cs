    public event EventHandler FooClicked;
    protected void OnFooClicked()
    {
        //  C#7. If this fails to compile with some weird error let me know and I'll 
        //  provide a backwards compatible version. 
        FooClicked?.Invoke(this, EventArgs.Empty);
    }
