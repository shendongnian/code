        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveThisNewValue();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SaveThisNewValue();
        }
        private void SaveThisNewValue()
        {
            //saves the cell value
        }
