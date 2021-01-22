    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
    }
