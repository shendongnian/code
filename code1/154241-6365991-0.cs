      private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (IsBirthdayColumn(e.ColumnIndex))
            {
                e.Value = dgv[e.ColumnIndex, e.RowIndex].Tag;
                if (e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToShortDateString();
                }
                e.FormattingApplied = true;
            }
        }
        private void dgv_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DateTime date;
            if (IsBirthdayColumn(e.ColumnIndex))
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out date))
                {
                    e.Value = date;
                    dgv[e.ColumnIndex, e.RowIndex].Tag = e.Value;
                }
                else
                {
                    dgv[e.ColumnIndex, e.RowIndex].Tag = e.Value;
                    e.Value = DBNull.Value;
                }
                e.ParsingApplied = true;
            }
        }
       private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DateTime date;
            if (IsBirthdayColumn(e.ColumnIndex))
            {
                var cell = dgv[e.ColumnIndex, e.RowIndex];
                if (e.FormattedValue != null && !DateTime.TryParse(e.FormattedValue.ToString(), out date))
                {
                    if (e.FormattedValue.ToString().Trim().Equals(""))
                    {
                        cell.ErrorText = string.Empty;
                        return;
                    }
                    cell.ErrorText = "Invalid date format";
                }
                else
                {
                    cell.ErrorText = string.Empty;
                }
            }
        }
