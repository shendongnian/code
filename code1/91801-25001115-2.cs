    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        { ((IMyViewModel)this.DataContext).Password = ((PasswordBox)sender).Password; }
    }
