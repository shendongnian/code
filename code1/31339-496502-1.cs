    protected void comboBoxAutoComplete_KeyPress(object sender, KeyPressEventArgs e) {
            ComboBox box = ((ComboBox)sender);
            string text = box.Text + e.KeyChar;
            bool matched = false;
            for (int i = 0; i < box.Items.Count; i++) {
                if (((DataRowView)box.Items[i])[box.DisplayMember].ToString().StartsWith(text)) {
                    matched = true;
                    break;
                }
            }
            e.Handled = matched;
        }
