    private void Chck_Checked(object sender, RoutedEventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        yourclass newVal = (yourclass)chk.Tag;
        if (chk.IsChecked.HasValue && chk.IsChecked.Value)
        {
            selectedItems.Add(newVal);
        }
        else
        {
            selectedItems.Remove(newVal);
        }
    }
