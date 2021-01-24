     protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            // Call home to base
            //base.OnCellFormatting(e);
            // First row always displays
            if (e.RowIndex == 0)
                return;
            if (IsRepeatedCellValue(e.RowIndex, e.ColumnIndex))
            {
                if (e.ColumnIndex == 0)
                    return;
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }
