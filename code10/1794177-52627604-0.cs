    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        TestConnection checkLogin = new TestConnection();
        string result = checkLogin.SimpleQuerry("SELECT Name FROM Names WHERE ID='1'", "");
        MessageBox.Show(result);
    }
