       DataGridViewRow BeginingRow = new DataGridViewRow();
       int BeginingRowIndex	;   
	        private void DataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left ||e.RowIndex < 0 ) return;
                if (BeginingRowIndex > e.RowIndex)
                {
                    DataGridView1.Rows.Insert(e.RowIndex);
                    foreach (DataGridViewCell cellules in BeginingRow.Cells)
                    {
                        DataGridView1.Rows[e.RowIndex].Cells[cellules.ColumnIndex].Value = cellules.Value;
                    }
                    DataGridView1.Rows.RemoveAt(BeginingRowIndex + 1);
                    
                }
                else
                {
                    DataGridView1.Rows.Insert(e.RowIndex +1);
                    foreach (DataGridViewCell cellules in BeginingRow.Cells)
                    {
                        DataGridView1.Rows[e.RowIndex+1].Cells[cellules.ColumnIndex].Value = cellules.Value;
                    }
                    DataGridView1.Rows.RemoveAt(BeginingRowIndex);
                }
                DataGridView1.RowsDefaultCellStyle.ApplyStyle(BeginingRow.DefaultCellStyle);
                DataGridView1.Rows[e.RowIndex].Selected = true;
        }
        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left ||e.RowIndex < 0 ) return;
                    BeginingRowIndex = e.RowIndex;
                    BeginingRow = DataGridView1.Rows[BeginingRowIndex];
                    BeginingRow.DefaultCellStyle = DataGridView1.Rows[BeginingRowIndex].DefaultCellStyle;
        }
