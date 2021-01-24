        // DataGridView EditControlShowing event
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Combobox column
            DataGridViewComboBoxEditingControl comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.KeyPress += ComboBox_KeyPress; // This function is below
            }
        }
        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Choose only list item
            if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                return;
            }
            string t = ((ComboBox)sender).Text;
            string typedT = t.Substring(0, ((ComboBox)sender).SelectionStart);
            string newT = typedT + e.KeyChar;
            int i = ((ComboBox)sender).FindString(newT);
            if (i == -1)
            {
                e.Handled = true;
            }
        }
