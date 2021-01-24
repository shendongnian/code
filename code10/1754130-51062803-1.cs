    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ColorWithInfo selectedItem = e.AddedItems[0] as ColorWithInfo;
        if (selectedItem != null)
            TextBox1.Text = selectedItem.Color.ToString();
    }
