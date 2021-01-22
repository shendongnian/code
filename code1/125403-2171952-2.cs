       private void DataGridView1_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e)    {
        
        System.Text.StringBuilder cellInformation = new System.Text.StringBuilder();
        cellInformation .AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
        cellInformation .AppendLine();
        cellInformation .AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
        cellInformation .AppendLine();
        MessageBox.Show(cellInformation.ToString(), "CellMouseClick Event" );
    }
