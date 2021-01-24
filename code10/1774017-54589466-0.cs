    private void button1_Click(object sender, EventArgs e)
    {
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridView1.DataSource = SourceList; // Your Collection here
        dataGridView1.AutoResizeRows();
    } 
