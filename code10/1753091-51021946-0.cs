    public SearchTest(DataTable TestData)
    {
        InitializeComponent();
        textBox1.DataBindings.Add("Text", TestData, "SomeDataCoulumnName");
        // other data bindings
        // assigning data source of the `DataGridView`
        // ....
    }
