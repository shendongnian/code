     bool authenticated = true;
        {
            if (usernameTextBox.Text !="" && passwordTextBox.Text != "")
            {
                authenticated = ValidateApplicationUser(usernameTextBox.Text , passwordTextBox.Text);
            }
            else
            {
                MessageBox.Show("Invalid login. Try again.");
            }
        }
        if (!authenticated)
        {
            MessageBox.Show("Invalid login. Try again.");
        }
        else
        {
            MessageBox.Show("Congradulations! You're a valid user!");
            InstituteHome c = new InstituteHome();
            c.ShowDialog();
        }
