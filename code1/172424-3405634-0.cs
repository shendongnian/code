     public class LagerStatusColumn : DataGridViewColumn
    {
        public LagerStatusColumn()
        {
            CellTemplate =
                new LagerStatusCell();
            ReadOnly = true;
        }
    }
     public class LagerStatusCell : DataGridViewTextBoxCell
    {
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, "", errorText, cellStyle,
                       advancedBorderStyle, paintParts);
            
            var cellValue = Convert.IsDBNull(value) ? 0 : Convert.ToDecimal(value);
            const int horizontaloffset = 2;
    
            var parent = (LagerStatusColumn)this.OwningColumn;
            var fnt = parent.InheritedStyle.Font;
            var icon = Properties.Resources.lager;
            if (cellValue == 0)
                icon = Properties.Resources.rest;
            else if (cellValue < 0)
                icon = Properties.Resources.question_white;
            const int vertoffset = 0;
            graphics.DrawIcon(icon, cellBounds.X + horizontaloffset,
                 cellBounds.Y + vertoffset);
            var cellText = formattedValue.ToString();
            var textSize =
                graphics.MeasureString(cellText, fnt);
            //  Calculate the correct color:
            var textColor = parent.InheritedStyle.ForeColor;
            if ((cellState &
                 DataGridViewElementStates.Selected) ==
                DataGridViewElementStates.Selected)
            {
                textColor = parent.InheritedStyle.
                    SelectionForeColor;
            }
            // Draw the text:
            using (var brush = new SolidBrush(textColor))
            {
                graphics.DrawString(cellText, fnt, brush,
                                    cellBounds.X + icon.Width + 2,
                                    cellBounds.Y + 0);
            }
        }
    }
