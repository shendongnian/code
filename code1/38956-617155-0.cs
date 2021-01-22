    public void Example()
    {
        var factory = new FrameworkElementFactory(typeof(TextBlock));
        factory.SetBinding(TextBlock.TextProperty, new Binding("Text"));
    
        var dataTemplate = new DataTemplate();
        dataTemplate.VisualTree = factory;
        dataTemplate.Seal();
    }
