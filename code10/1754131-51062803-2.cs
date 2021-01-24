    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            var selectedItem = (ColorWithInfo)e.AddedItems[0];
            TextBox1.Text = selectedItem.Color.ToString();
        }
    }
