      private void dgJobNotes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if ((e.ColumnIndex == this.dgJobNotes.Columns["Added By"].Index)
                && e.Value != null)
                {
       dgJobNotes.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = dgJobNotes.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
