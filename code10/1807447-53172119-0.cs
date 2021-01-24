    //Define which Column contains an Image
    int ImageColumn = 2;
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        if (column.Index != ImageColumn)
        {
            column.Frozen = true;
            column.ReadOnly = true;
        }
    }
