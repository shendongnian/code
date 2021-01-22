    private void MyExampleButton_Click(object sender, RoutedEventArgs e)
    {
        if ((Keyboard.Modifiers & ModifierKeys.Control) > 0) {
            System.Diagnostics.Debug.WriteLine("Control is pressed");
        } else {
            System.Diagnostics.Debug.WriteLine("Control is NOT pressed");
        }
    }
