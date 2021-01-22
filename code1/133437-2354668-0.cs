    MultiBinding multiBinding = new MultiBinding();
    multiBinding.Converter = converter;
    
    multiBinding.Bindings.Add(new Binding
    {
        ElementName = "FirstSlider",
        Path = new PropertyPath("Value")
    });
    multiBinding.Bindings.Add(new Binding
    {
        ElementName = "SecondSlider",
        Path = new PropertyPath("Value")
    });
    multiBinding.Bindings.Add(new Binding
    {
        ElementName = "ThirdSlider",
        Path = new PropertyPath("Value")
    });
