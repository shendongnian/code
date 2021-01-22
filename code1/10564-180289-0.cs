    public class MyTextBoxCell : DataGridViewTextBoxCell{ ....
            private static readonly int INDENTCOEFFICIENT = 5;
            protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize) {
                int indent = ((MyRow)OwningRow).Indent * INDENTCOEFFICIENT;
                Size s =  base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
                int textWidth = 2;  //arbitrary amount
                if (Value != null) {
                    string text = Value as string;
                    textWidth = TextRenderer.MeasureText(text, cellStyle.Font).Width;
                }
    
                s.Width += textWidth + indent;
                return s;
            }
            
            private static readonly StringFormat strFmt = new StringFormat(StringFormatFlags.NoWrap);
    
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
    
                DataGridViewPaintParts pp = DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground
                    | DataGridViewPaintParts.ErrorIcon;
    
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, pp);
    
                string text = formattedValue as string;
    
                int indent = ((MyRow)OwningRow).Indent * INDENTCOEFFICIENT;
                strFmt.Trimming = StringTrimming.EllipsisCharacter;
                Rectangle r = cellBounds;
                r.Offset(indent, 0);
                r.Inflate(-indent, 0);
                graphics.DrawString(text, cellStyle.Font, Brushes.Black, r, strFmt);
            }
    
    }
