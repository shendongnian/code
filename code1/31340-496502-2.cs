        protected virtual void comboBoxAutoComplete_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsControl(e.KeyChar)) {
                //let it go if it's a control char such as escape, tab, backspace, enter...
                return;
            }
            ComboBox box = ((ComboBox)sender);
            //must get the selected portion only. Otherwise, we append the e.KeyChar to the AutoSuggested value (i.e. we'd never get anywhere)
            string nonSelected = box.Text.Substring(0, box.Text.Length - box.SelectionLength);
            string text = nonSelected + e.KeyChar;
            bool matched = false;
            for (int i = 0; i < box.Items.Count; i++) {
                if (((DataRowView)box.Items[i])[box.DisplayMember].ToString().StartsWith(text, true, null)) {
                    matched = true;
                    break;
                }
            }
            //toggle the matched bool because if we set handled to true, it precent's input, and we don't want to prevent
            //input if it's matched.
            e.Handled = !matched;
        }
