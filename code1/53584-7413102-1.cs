    private void userNameWatermarked_GotFocus(object sender, RoutedEventArgs e)
        {
            userNameWatermarked.Visibility = System.Windows.Visibility.Collapsed;
            userName.Visibility = System.Windows.Visibility.Visible;
            userName.Focus();
        }
        private void userName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.userName.Text))
            {
                userName.Visibility = System.Windows.Visibility.Collapsed;
                userNameWatermarked.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void passwordWatermarked_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordWatermarked.Visibility = System.Windows.Visibility.Collapsed;
            password.Visibility = System.Windows.Visibility.Visible;
            password.Focus();
        }
        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.password.Password))
            {
                password.Visibility = System.Windows.Visibility.Collapsed;
                passwordWatermarked.Visibility = System.Windows.Visibility.Visible;
            }
        }
