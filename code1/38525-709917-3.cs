     bool authenticated = true;
        {
            if (usernameTextBox.Text !="" && passwordTextBox.Text != "")
            {
                authenticated = ValidateApplicationUser(usernameTextBox.Text , passwordTextBox.Text);
            }
           
        }
        if (!authenticated || usernameTextBox.Text == "" || passwordTextBox.Text == "")
        {
            MessageBox.Show("Invalid login. Try again.");
        }
        else
        {
            MessageBox.Show("Congradulations! You're a valid user!");
            MainWindow c = new MainWindow();
            c.ShowDialog();
        }
