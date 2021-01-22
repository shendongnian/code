            if ((int)comboBox.Tag == comboBox.SelectedIndex)
            {
                // Do Nothing
            }
            else
            {
                if (MessageBox.Show("") == DialogResult.Cancel)
                {
                    comboBox.SelectedIndex = (int)comboBox.Tag;
                }
                else
                {
                    // Reset the Tag
                    comboBox.Tag = comboBox.SelectedIndex;
                    // Do what you have to
                }
            }
