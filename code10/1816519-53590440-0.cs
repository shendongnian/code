    async void LoginButton_Click(object sender, EventArgs e)
    {
        // This runs on the UI thread
        string login = loginTextBox.Text;
        string password = pwdTextBox.Text;
        loginButton.Enabled = false;
        // This will be executed asynchronously, in your case - on a worker thread
        bool success = await Task.Run(() => myLoginProcessor.Login(login, password));
        // This runs again on the UI thread, so you can safely access your controls
        if (success)
        {
            labelResult.Text = "Successfully logged in.";
        }
        else
        {
            labelResult.Text = "Invalid credentials.";
        }
        loginButton.Enabled = true;
    }
