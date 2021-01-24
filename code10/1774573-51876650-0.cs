    private void multiCombo_TextChange(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Dictionary<string, int> searchedItem = new Dictionary<string, int>(); 
            searchedItem = (GetFacility(data, textBox.Text));
            Dictionary<string, int> selectedItems = new Dictionary<string, int>();
            Dictionary<string, int> allItems = new Dictionary<string, int>();
            foreach (var item in searchedItem)
            {
                allItems.Add(item.Key, item.Value);
            }
            //multiCombo.SelectedItems.Clear();
            foreach (var selectedItem in multiCombo.SelectedItems)
            {
                selectedItems.Add(selectedItem.Key, selectedItem.Value);
            }
            
            foreach (var select in selectedItems)
            {
                if (!allItems.ContainsKey(select.Key))
                {
                    allItems.Add(select.Key, select.Value);
                }
            }
            multiCombo.ItemsSource = allItems;
            foreach (var selected in selectedItems)
            {
                if (!multiCombo.SelectedItems.ContainsKey(selected.Key))
                {
                    multiCombo.SelectedItems.Add(selected.Key, selected.Value);
                }
                
            }
        }
