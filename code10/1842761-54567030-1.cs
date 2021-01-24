    public MyClass()
    {
        InitializeComponent();
        entry2.OnBackspace += BackspaceEventHandler ;
    }
    private void BackspaceEventHandler(object sender, EventArgs e)
    {
        entry1.Focus();
    }
