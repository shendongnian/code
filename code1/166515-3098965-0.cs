    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void btnName_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("This is from btnName");
    }
    
    private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Left)
        {
            btnName_Click(sender, new RoutedEventArgs());
            e.Handled = true;
        }
    }
