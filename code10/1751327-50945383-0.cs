    public class MyDataGridViewControl : DataGridView
    {
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Boolean handled = false;
            if ((keyData == Keys.Enter || keyData == Keys.Return))
            {
                handled = NavigateToNextCell();
            }
            if (!handled)
            {
                handled = base.ProcessCmdKey(ref msg, keyData);
            }
            return handled;
        }
        private Boolean NavigateToNextCell()
        {
            Boolean retVal = false;
            if (CurrentCell != null)
            {
                Int32 columnIndex = CurrentCell.ColumnIndex;
                Int32 rowIndex = CurrentCell.RowIndex;
                DataGridViewCell targetCell = null;
                do
                {
                    if (columnIndex >= Columns.Count - 1)
                    {
                        // Move to the start of the next row
                        columnIndex = 0;
                        rowIndex = rowIndex + 1;
                    }
                    else
                    {
                        // Move to the next cell on the right
                        columnIndex = columnIndex + 1;
                    }
                    if (rowIndex >= RowCount)
                    {
                        break;
                    }
                    else
                    {
                        targetCell = this[columnIndex, rowIndex];
                    }
                } while (targetCell.Visible == false);
                if (targetCell != null)
                {
                    CurrentCell = targetCell;
                }
                retVal = true;
            }
            return retVal;
        }
    }
