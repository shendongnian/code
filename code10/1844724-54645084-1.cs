    try
    {
        if(e.ColumnIndex == indexOfCheckBoxColumn)
        {
           if((bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
           {
            CachedRows.Add((DataGridViewRow)dataGridView1.Rows[e.RowIndex].Clone());
           }
           else if (CachedRows.Contains(dataGridView1.Rows[e.RowIndex]))//Validate if this works, if not you should associate each row with unique key like for example (id) using a dictionary
           {
              CachedRows.Remove(dataGridView1.Rows[e.RowIndex]);
           }
        }
    }
    catch(Exception ex)
    {
    }
