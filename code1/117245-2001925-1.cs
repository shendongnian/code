    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
         // Check the value of the e.ColumnIndex property if you want to apply this formatting only so some rcolumns.
         if (e.Value != null) {
             e.Value = e.Value.ToString().ToUpper();
             e.FormattingApplied = true;
         }
    }
