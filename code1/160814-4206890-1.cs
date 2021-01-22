    private void AppName_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       ComboBoxItem cbi = (ComboBoxItem)AppName.SelectedItem;
       string selectedText = cbi.Content.ToString();
    }
