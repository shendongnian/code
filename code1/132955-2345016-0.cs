    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.RowCount >=1)
        {
            DataGridViewRow currentRow = new DataGridViewRow();
            currentRow = dataGridView1.CurrentRow;
            string valueJob = currentRow.Cells[2].Value.ToString();
            string valueBatch = currentRow.Cells[3].Value.ToString();
            string valueImmagine = currentRow.Cells[4].Value.ToString();
    
            string result = Octopus2.Properties.Settings.Default.DataPath + "\\" + valueJob + "\\" + valueBatch + "\\" + valueImmagine + ".jpg";
    
            pictboxImpegnativa.ImageLocation = result;
        }
        else
        {
            MessageBox.Show("good work.");
        }
    }
