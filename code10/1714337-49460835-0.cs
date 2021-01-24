    public class MyTextBoxCell : DataGridViewTextBoxCell
    {
        public override void PositionEditingControl(bool setLocation, bool setSize,
            Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, 
            bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, 
            bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            cellClip.Height = cellClip.Height *4; // ← Or any other suitable height
            cellBounds.Height = cellBounds.Height * 4;
            var r = base.PositionEditingPanel( cellBounds, cellClip, cellStyle, 
                singleVerticalBorderAdded, singleHorizontalBorderAdded, 
                isFirstDisplayedColumn, isFirstDisplayedRow);
            this.DataGridView.EditingControl.Location = r.Location;
            this.DataGridView.EditingControl.Size = r.Size;
        }
        public override void InitializeEditingControl(int rowIndex,
            object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, 
                dataGridViewCellStyle);
            ((TextBox)this.DataGridView.EditingControl).Multiline = true;
            ((TextBox)this.DataGridView.EditingControl).BorderStyle = BorderStyle.Fixed3D;
        }
    }
