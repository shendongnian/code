        private DataGridViewRow CurrentRow;
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs dataGridViewEditingControlShowingEventArgs)
        {
            CurrentRow = dataGridView1.CurrentRow;
            TextBox textBox = dataGridViewEditingControlShowingEventArgs.Control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged -= textBox_TextChanged;
                textBox.TextChanged += textBox_TextChanged;
            }
        }
        private void textBox_TextChanged(object sender, EventArgs eventArgs)
        {
            TextBox textBox = (TextBox)sender;
            decimal a = Convert.ToDecimal(CurrentRow.Cells[2].Value);
            decimal b = Convert.ToDecimal(CurrentRow.Cells[3].Value);
            decimal c = a * b;
            CurrentRow.Cells[4].Value = c.ToString();
        }
