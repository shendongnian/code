        private void comboBoxThickness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               var selectedItem = comboBoxThickness.SelectedItem as ComboBoxItem;
               if(selectedItem.Content.ToString() == "8mm")
                {
                    // Write your logic here
                }
        }
