    // Filter out non-numeric keys.
    private void MyApp_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
    String sKeys = "1234567890";
    if (!sKeys.Contains(e.Text))
        e.Handled = true;
    }
