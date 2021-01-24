    private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            p = p+1;
            if (p == 1)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    brand = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    datadisp();
                }
            }
        }
    }
