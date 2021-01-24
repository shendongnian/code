    Style style = this.FindResource("backColor") as Style;
    Style styleNX = this.FindResource("backColorNX") as Style;
    if (DataGridClientFile.Columns.Count >= 14)
                {
                    DataGridColumn col = DataGridClientFile.Columns[14];
                    col.CellStyle = style;
                    DataGridColumn colNX = DataGridClientFile.Columns[15];
                    colNX.CellStyle = styleNX;
                }
