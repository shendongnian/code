    private void button1_Click(object sender, EventArgs e)
    {
        //You can use either of the following ways:
        dataGridView1[1, 1].Value = "C";
        //dataGridView1["comboBoxColumn", 1].Value = "C";
        //dataGridView1.Rows[1].Cells["comboBoxColumn"].Value = "C";
        //dataGridView1.Rows[1].Cells[1].Value = "C";
    }
