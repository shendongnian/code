    private void ButtonCellWithValue()
    {
        DataGridViewButtonCell dgvbc = new DataGridViewButtonCell();
    
        dgvbc.Value = "1";
                    
        DataGridViewRow dgvr = new DataGridViewRow();
    
        dgvr.Cells.Add(dgvbc);
    
        dataGridView1.Rows.Add(dgvr);
       
        dgvbc = new DataGridViewButtonCell();
    
        dgvbc.Value = "2";
    
        dataGridView1.Rows[0].Cells[1] = dgvbc;
        GridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
    }
    
    void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (((DataGridView)sender).CurrentCell.Value == "1")
        {
            MessageBox.Show("Super");
        }
        else if (((DataGridView)sender).CurrentCell.Value == "2")
        {
            MessageBox.Show("Better");
        }
    }
