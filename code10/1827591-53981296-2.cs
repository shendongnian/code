        if(UserNameInput.Text == userName && PasswordInput.Text == password)
        {
            failedAttempts = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            failedAttempts++;
            if(failedAttempts >= 3)
            {
                MessageBox.Show("Wrong password. Shutting down the application...");
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong password. " + (3-failedAttempts) + " tries left.");
            }
        }
    }
