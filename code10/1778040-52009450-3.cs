    private void ComboBox_LostFocus(Object sender, RoutedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox != null)
        {
            int id;
            if(int.TryParse(comboBox.Text, out id))
            {
                // do your thing!!!!
            }
        }
    }
