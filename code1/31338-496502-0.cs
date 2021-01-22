    private void comboBoxAutocomplete_KeyPress(object sender, KeyPressEventArgs e) {            
                string text = ((ComboBox)sender).Text + e.KeyChar;
                bool matched = false;
                for (int i = 0; i < ((ComboBox)sender).Items.Count; i++) {
                    if((((DataRowView)((ComboBox)sender).Items[i])[((ComboBox)sender).DisplayMember].ToString().StartsWith(text))){
                        matched = true;
                        break;
                    }
                }
                e.Handled = matched;
            }
