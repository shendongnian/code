    dataGridView1.AutoGenerateColumns = false; // disable columns auto generation
    
    ... add all columns
    
    // add your special column
    col = new MyColumn();
    col.DataPropertyName = "Text"; // bind with the corresponding property
    dataGridView1.Columns.Add(col); // add the custom column
    
    ... add other columns
    
    public class MyCell : DataGridViewTextBoxCell
    {
        public override Rectangle PositionEditingPanel(Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            cellBounds.Width *= 2;
            cellClip.Width = cellBounds.Width;
            return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
        }
    }
    
    public class MyColumn : DataGridViewTextBoxColumn
    {
        public MyColumn()
        {
            CellTemplate = new MyCell();
        }
    }
