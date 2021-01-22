    private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
               //change tablenameDataTable: yours! and tablenameViewSource: yours!
               tablenameDataTable.Rows[tablenameViewSource.View.CurrentPosition]["password"] = NewPassword.Password;
            }
            catch
            {
                this.Password.Text = this.NewPassword.Password;
            }
        }
