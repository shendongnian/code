    protected void ClickMeClick(object sender, RoutedEventArgs e)
    {
        Button btnClickMe = sender as Button;
        if (btnClickMe != null)
        {
            TextBox txtNumber = btnClickMe.Tag as TextBox;
            // ...
        }
    }
