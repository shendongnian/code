    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MyLabel : Label {
      protected override void OnPaint(PaintEventArgs e) {
        Rectangle rc = this.ClientRectangle;
        StringFormat fmt = new StringFormat(StringFormat.GenericTypographic);
        using (var br = new SolidBrush(this.ForeColor)) {
          e.Graphics.DrawString(this.Text, this.Font, br, rc, fmt);
        }
      }
    }
