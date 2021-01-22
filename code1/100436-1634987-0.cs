    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; --i)
        {
            var r = dataGridView1.SelectedRows[i];
            MessageBox.Show(r.Cells[0].Value.ToString());
        }
            
     }
