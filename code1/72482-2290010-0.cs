    private void AddRow(Control label, Control value)
    {
        int rowIndex = AddTableRow();
        detailTable.Controls.Add(label, LabelColumnIndex, rowIndex);
        if (value != null)
        {
            detailTable.Controls.Add(value, ValueColumnIndex, rowIndex);
        }
    }
    private int AddTableRow()
    {
        int index = detailTable.RowCount++;
        RowStyle style = new RowStyle(SizeType.AutoSize);
        detailTable.RowStyles.Add(style);
        return index;
    }
