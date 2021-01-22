        private int lastMatch = 0;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Set our intial index variable to -1.
            int x = 0;
            string match = textBoxSearch.Text;
            // If the search string is empty set to begining of textBox
            if (textBoxSearch.Text.Length != 0)
            {
                bool found = true;
                while (found)
                {
                    if (comboBoxSelect.Items.Count == x)
                    {
                        comboBoxSelect.SelectedIndex = lastMatch;
                        found = false;
                    }
                    else
                    {
                        comboBoxSelect.SelectedIndex = x;
                        match = comboBoxSelect.SelectedValue.ToString();
                        if (match.Contains(textBoxSearch.Text))
                        {
                            lastMatch = x;
                            found = false;
                        }
                        x++;
                    }
                }
            }
            else
                comboBoxSelect.SelectedIndex = 0;
        }
