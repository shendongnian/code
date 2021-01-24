    public class MYButton:Button
        {
            public MYButton()
            {
                UseVisualStyleBackColor = false;
                TextImageRelation = TextImageRelation.ImageAboveText;
    
            }
            public override string Text
            {
                get { return ""; }
                set { base.Text = value; }
            }
            public string TextCenter { get; set; }
            public string TextDetails { get; set; }
    
            Font fontTextCenter { get; set; }
            Font fontTextDetails { get; set; }
    
            protected override void OnPaint(PaintEventArgs pevent)
            {
                fontTextCenter = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
                fontTextDetails = new Font("Microsoft Sans Serif", 8F);
                base.OnPaint(pevent);
                Rectangle rect = ClientRectangle;
                rect.Inflate(-5, -5);
    
                StringFormat sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
    
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
    
                Brush brush = new SolidBrush(ForeColor);
                pevent.Graphics.DrawString(TextCenter, fontTextCenter, brush, rect, sf);
    
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Far;
                sf.FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
    
                pevent.Graphics.DrawString(TextDetails, fontTextDetails, brush, rect, sf);
                    
                
            }
    
    
        }
