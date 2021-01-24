    public string TestString { get; set; }
    public ucnTest(string myStringValue)
    {
        InitializeComponent();
        TestString = myStringValue;
        MessageBox.Show(TestString);
    }
