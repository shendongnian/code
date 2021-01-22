        protected void autocomplete_LeaveFocus(object sender, EventArgs e) {
            ComboBox box = ((ComboBox)sender);
            String selectedValueText = box.Text;
            
            //search and locate the selected value case insensitivly and set it as the selected value
            for (int i = 0; i < box.Items.Count; i++) {
                if (((DataRowView)box.Items[i])[box.DisplayMember].ToString().Equals(selectedValueText, StringComparison.InvariantCultureIgnoreCase)) {
                    box.SelectedItem = box.Items[i];
                    break;
                }
            }
        }
