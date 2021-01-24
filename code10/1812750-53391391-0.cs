    public string Email { get; set; }
    public void Login_Click(object sender, RoutedEventArgs e)
    {
        Email = InputEmail.Text;
    }
----------
    string email = loginWindow.Email;
