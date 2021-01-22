    public class MyListView : ListView
    {
        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case 0x0F: // WM_PAINT
                    this.HandlePaint(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    
        protected virtual void HandlePaint(ref Message m) {
            base.WndProc(ref m);
    
            using (Graphics g = this.CreateGraphics()) {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                g.DrawString("Some text", new Font("Tahoma", 13),
                    SystemBrushes.ControlDark, this.ClientRectangle, sf);
            }
        }
    }
