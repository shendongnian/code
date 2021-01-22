    // use custom DataGridViewTextBoxCell as columns's template
    col.CellTemplate = new MyDataGridViewTextBoxCell();
...
    // custom DataGridViewTextBoxCell implementation 
    public class MyDataGridViewTextBoxCell : DataGridViewTextBoxCell
    {
        protected override Object GetFormattedValue(Object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            return String.Format("{0} per {1}",
                this.DataGridView.Rows[rowIndex].Cells[0].Value,
                this.DataGridView.Rows[rowIndex].Cells[1].Value);
        }
    }
