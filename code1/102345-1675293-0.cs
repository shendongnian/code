        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Focused)
            {
                checkBox2.Checked = checkBox1.Checked;
                checkBox3.Checked = checkBox1.Checked;
                checkBox4.Checked = checkBox1.Checked;
            }
        }
        private void subCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox theCheckbox = sender as CheckBox;
            if (theCheckbox.Focused)
            {
                checkBox1.Checked = checkBox2.Checked || checkBox3.Checked || checkBox4.Checked;
            }
        }
