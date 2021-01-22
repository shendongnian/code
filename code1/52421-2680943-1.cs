    foreach (DataGridViewRow row in this.dataGridView1.Rows)
    {                            
        foreach (DataGridViewCell cell in row.Cells[1])
        {
           if (cell[1].Value == null || cell.Value.Equals(""))
    {
        continue;
    }
    
            MessageBox.Show(cell[1].Value.ToString());
        }
    }
