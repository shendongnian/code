    void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            {
               e.Cancel = false;
               if (e.RowIndex == 1 && e.ColumnIndex == 0)
                {
                   if(string.IsNullorEmpty(e.FormattedValue.ToString())
                      // method call
                }
            }
