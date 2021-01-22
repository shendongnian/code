    public string YourText { get; set; }
    public TestForm()
    {
        InitializeComponent();
    }
    public void UpdateValues()
    {
        someLabel.Text = YourText;
    }
