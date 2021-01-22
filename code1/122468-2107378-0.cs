    private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        MessageBox.Show("Column Width Changed");
        widthChanged(sender, e);
    }
    
    private void dataGridView1_RowHeadersWidthChanged(object sender, EventArgs e)
    {
        MessageBox.Show("Row Header Width Changed");
        widthChanged(sender, null);
    }
    
    private void widthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        MessageBox.Show("Any Width Changed");
    }
