    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
        this.dataGridView1.Rows[0].Cells[0].Value = comboBox1.Text;
    }
    
    private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
    {
        this.dataGridView1.Rows[0].Cells[1].Value = comboBox2.Text;
    }
