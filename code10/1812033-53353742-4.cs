        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex(@"[^\d]");
            if (myRegex.IsMatch(PasswordBox1.Password))
                PasswordBox1.Password = myRegex.Replace(PasswordBox1.Password, "");
        }
