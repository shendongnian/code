    // Get all available checkboxes in the StackPanel's children.
    var checkBoxes = myStackPanel.Children.OfType<CheckBox>();
    for (int i = 0; i < checkBoxes.Count; i++)
    {
        MessageBox.Show(checkBoxes[i].Content + ": " checkBoxes[i].IsChecked.ToString());
        // GPIO 1: true
        // GPIO 2: false
        // etc...
    }
    
    // Get first checkbox state
    MessageBox.Show(checkBoxes[0].IsChecked.ToString());
