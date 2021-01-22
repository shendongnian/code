    private void Login(object parameter)
    {
        System.Windows.Controls.PasswordBox p = (System.Windows.Controls.PasswordBox)parameter;
        MessageBox.Show(p.Password);
    }
