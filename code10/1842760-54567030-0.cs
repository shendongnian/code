    public MyClass()
    {
        InitializeComponent();
        entry2.OnBackspace += (sender, e) => entry1.Focus();
    }
