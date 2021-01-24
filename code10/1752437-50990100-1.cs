    private void ComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        cb.IsDropDownOpen = true;
        foreach (ComboBoxItem item in cb.Items)
        {
            var str = (string)item.Content;
            if(str.Contains(e.Text))
            {
                cb.SelectedItem = item;
                break;
            }
        }
    }
