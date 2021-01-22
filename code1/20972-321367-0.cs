    private void Button_Click(object sender, RoutedEventArgs e) {
        if (panel1.Visibility == Visibility.Collapsed) {
            panel1.Visibility = Visibility.Visible;
            DataBoundTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            panel2.Visibility = Visibility.Collapsed;
        }
        else {
            panel1.Visibility = Visibility.Collapsed;
            DataBoundTextBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            panel2.Visibility = Visibility.Visible;
        }
    }
