            if (textBox1.Text != "")
            {
                textBox1.MaxLength = 15;
                // Change all text entered to be lowercase.
                textBox1.CharacterCasing = CharacterCasing.Lower;
                if (checkedListBox1.Items.Contains(textBox1.Text) == false)
                {
                    checkedListBox1.Items.Add(textBox1.Text, CheckState.Checked);
                    textBox1.Text = "";
                    MessageBox.Show("Added! Click Move to see List Box");
                }
                else
                {
                    MessageBox.Show("Already There!");
                    textBox1.Text = "";
                }
            }
        }
