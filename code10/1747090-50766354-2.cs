        private void fontBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbox = (ComboBox)sender;
            ComboBoxItem t = (ComboBoxItem) cbox.SelectedItem;
            string NewSetting = (string) t.Content;            
            int temp;
            if (Int32.TryParse(NewSetting, out temp))
            {
                if(txtEditor != null)
                    txtEditor.FontSize = temp;
            }
        }
