    private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (myComboBox.SelectedItem == null) 
        { 
          buttonApply.IsEnabled = false;
        }
        else 
        {
          buttonApply.IsEnabled = true;
        }
    }
