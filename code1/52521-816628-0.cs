    foreach (DataGridViewRow row in this.dataGridView2.Rows)
    {                            
        DataGridViewCell cell = row.Cells[2]; //Note specified column index
        if (cell.Value == null || cell.Value.Equals(""))
        {
            continue;
        }
        GetQuestions(cell.Value.ToString());
    }
