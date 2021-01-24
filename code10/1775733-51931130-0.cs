    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        string password = "|NOMATCH|";
        List<PasswordBox> pb = new List<PasswordBox>(2) { };
        List<string> s = new List<string>[2] { SHA512(pb1.Password), SHA512(pb2.Password) };
        if (s[0] == s[1])
            password = s[0];
        btn.CommandParameter = password;
    }
