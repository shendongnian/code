    public MainWindow()
    {
        InitializeComponent();
        OldeFashonedCombo.Items.Add("One");
        OldeFashonedCombo.Items.Add("Two");
        OldeFashonedCombo.Items.Add("Three");
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        OldeFashonedCombo.SelectedItem = "Two";
    }
