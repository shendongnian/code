            bool isSelectionHandled = true;
    
            void CmbBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (isSelectionHandled)
                {
                    MessageBoxResult result = MessageBox.Show("Do you wish to continue selection change?", this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        ComboBox combo = (ComboBox)sender;
                        isSelectionHandled = false;
                        if (e.RemovedItems.Count > 0)
                            combo.SelectedItem = e.RemovedItems[0];
                        return;
                    }
                }
                isSelectionHandled = true;
            }
