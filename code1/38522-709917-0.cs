private void mahhh(object sender, RoutedEventArgs e)
    {
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
            MainWindow c = new MainWindow();
            c.ShowDialog();
        }
}
