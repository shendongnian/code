    private void MyComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
        foreach (ComboBoxItem i in MyComboBox.Items) {
            if (i.Content.ToString().ToUpper().Contains(e.Text.ToUpper())) {
                MyComboBox.SelectedItem = i;
                break;
            }
        }
        e.Handled = true;
    }
