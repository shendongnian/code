    private void login_OnClick(object sender, RoutedEventArgs e)
    {
        string userType = cmbAdminType.Text;
        string uniqueCode = txtUniqueCode.Text;
        string password = txtPassword.Text;
        bool isMatched = false;
        foreach (User userPick in users)
        {        
            if (userPick.userType == userType && userPick.uniqueCode == uniqueCode)
            {
                isMatched = true;
                break;
            }
        }
        if (isMatched)
        {
            MessageBox.Show("Cool you are in!");
        }
        else
        {
            MessageBox.Show("Err, not found!");
        }
    }
