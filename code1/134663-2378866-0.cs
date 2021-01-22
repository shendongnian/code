        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (numericUpDown1.Controls[1].Text == String.Empty)
            {
                numericUpDown1.Controls[1].Text = numericUpDown1.Minimum.ToString();
                numericUpDown1.Value = numericUpDown1.Minimum;
            }
        }</pre></code>
