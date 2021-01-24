    private void dgv_CellFormatting(object sender, 
    DataGridViewCellFormattingEventArgs e)
    {
        if (dgv.Columns[e.ColumnIndex].Name == "Image")
        {
            if (e.Value != null)
            {
                ... convert byte[] to image...
            }
        }
     }
