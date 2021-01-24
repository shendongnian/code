    private void SaveClick(object sender, RoutedEventArgs e)
    {
        if (!(e.OriginalSource is CheckBox))
        {
            Button button = (Button)sender;
            CheckBox templatedCheck = button.Template.FindName("checkbox", button) as CheckBox;
            if (templatedCheck != null)
                Debug.Print(templatedCheck.IsChecked.ToString());
        }
    }
