        private void fontBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem) e.AddedItems[0];
            
            int temp;
            if (Int32.TryParse((string) cbi.Content, out temp))
            {
                if(txtEditor != null)
                    txtEditor.FontSize = temp;
            }
        }
