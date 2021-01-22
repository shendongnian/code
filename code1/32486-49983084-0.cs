    private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                e.Handled = true;
                return;
            }
            if (comboBox1.Text.Length < 3)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyCode == Keys.Back)
            {
                e.Handled = true;
                return;
            }
            string text = comboBox1.Text;
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.DroppedDown = false;
                comboBox1.SelectionStart = text.Length;
                e.Handled = true;
                return;
            }
            List<string> LS = Suggestions(comboBox1.Text);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(LS.ToArray());
            //If you do not want to Suggest and Append
            //comment the following line to only Suggest
            comboBox1.Focus();
            comboBox1.DroppedDown = true;
            comboBox1.SelectionStart = text.Length;
            //Prevent cursor from getting hidden
            Cursor.Current = Cursors.Default;
            e.Handled = true;
        }
