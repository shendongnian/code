    public void Foo(ref Control control)
    {
        control = new TextBox();
    }
    
    public void Main()
    {
        Button button = new Button();
    
        Foo(ref button);
    
        // Now your button magically became a text box ...
    }
