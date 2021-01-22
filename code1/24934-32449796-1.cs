        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewImageCell))) return;
            System.Windows.Forms.ToolTip tlp = new System.Windows.Forms.ToolTip();
            tlp.SetToolTip(dgv, "Your ToolTipText");
        }
