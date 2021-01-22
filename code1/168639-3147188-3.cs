    public frmFoo()
    {
        InitializeComponent();
        lblTest.DataBindings.Add(new Binding("Text", this, "Foo"));
    }
