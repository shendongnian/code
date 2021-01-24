    public Form1()
    {
        InitializeComponent();
        // add the custom type description provider
        var prov = new NeverImmutableProvider(typeof(TestClass3));
        TypeDescriptor.AddProvider(prov, typeof(TestClass3));
        
        // run the property grid
        var c2 = new TestClass2();
      
        propertyGrid1.SelectedObject = c2;
    }
