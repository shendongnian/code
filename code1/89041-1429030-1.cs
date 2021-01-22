    public void DoDarkMagic(ref Control control)
    {
        control = new TextBox();
    }
    
    public void Main()
    {
        Button button = new Button();
    
        DoDarkMagic(ref button);
    
        // Now your button magically became a text box ...
    }
