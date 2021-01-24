    private void vmS_TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = this.iBoxEventlistSearchTextBox.Text;
            // Save the selected item before
            var selectedItem = lBox_Event_list.SelectedItem;
            lBox_Event_list.Items.Clear();
    
            foreach (string item in sortedEventList)
            {
                if (item.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lBox_Event_list.Items.Add(item);
                }
            }
            // Search for it in the items and set the selected item to that
            var index = lBox_Event_list.Items.IndexOf(selectedItem);
            if(index != -1)
              lBox_Event_list.SelectedIndex = index;
        }  
   
