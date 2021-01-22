    private void button1_Click(object sender, EventArgs e)
    {
        LoginBox login = new LoginBox();
        if (login.ShowDialog() == DialogResult.OK) // Let the user input their credentials and click OK or Cancel
        {
            if (!login.ValidateCredentials) // Perform the authentication with the collected credentials
            {
                MessageBox.Show("The specified Credentials were invalid!");
            }
        }
    }
