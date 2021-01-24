    private void updateExcel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
        {
            if(_your_logic_here_)
                dataGridView1[2, i].Value = ConsigneeCombo.Text;
        }
    }
