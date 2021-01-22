    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
        ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
    
        if (ch1.Value == null)
            ch1.Value=false;
        switch (ch1.Value.ToString())
        {
            case "True":
                ch1.Value = false;
                break;
            case "False":
                ch1.Value = true;
                break;
        }
        MessageBox.Show(ch1.Value.ToString());
    }
