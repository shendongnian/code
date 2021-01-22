    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
       if (dataGridView1.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
        {
            SendKeys.Send("{tab}");
        }
    }
