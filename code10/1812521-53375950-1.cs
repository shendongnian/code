    public(int id, bool confirmed)
    {
        InitializeComponent(); 
    }
    
    private void btnYes_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
    
    private void btnNo_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
