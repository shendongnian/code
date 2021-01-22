    private String username = "";
    private void usernameTextBox_GotFocus(object sender, RoutedEventArgs e) {
      if (String.IsNullOrEmpty(username)) {
        usernameTextBox.Text = "";
      }
    }
    private void usernameTextBox_LostFocus(object sender, RoutedEventArgs e) {
      username = usernameTextBox.Text;
      if (String.IsNullOrEmpty(usernameTextBox.Text)) {
        usernameTextBox.Text = "Username";
      }
    }
