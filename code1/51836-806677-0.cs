    public class Painter
    {
        Color foreColor;
        Color backColor;
        Color altBackColor;
        Color buttonColor;
        Font font;
        
        public Painter(Color foreColor, Color backColor, Color altBackColor, Color buttonColor, Font font)
        {
            this.foreColor=foreColor;
            this.backColor=backColor;
            this.altBackColor=altBackColor;
            this.buttonColor=buttonColor;
            this.font=font;
        }    
        
        public void Apply(Control c)
        {
            if(c==null)
                return;
    
            c.ForeColor = foreColor;
    
            c.BackColor = (c is Button ) ? buttonColor
                                         : backColor;
    
            if (c is DataGridView)
            {
                var dgv = (DataGridView) c;
                dgv.BackgroundColor = BackColor;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = altBackColor;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = buttonColor;
            }
    
            c.Font = font;
    
            foreach(Control child in c.Controls)
                Apply(child);
        }
    }
