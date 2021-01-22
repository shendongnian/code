    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MyPictureBox : Control {
      private Image mImage;
      public Image Image {
        get { return mImage; }
        set { mImage = value; Invalidate(); }
      }
      protected override void OnPaintBackground(PaintEventArgs pevent) {
        // Do nothing
      }
      protected override void OnPaint(PaintEventArgs e) {
        using (Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height)) {
          using (Graphics bgr = Graphics.FromImage(bmp)) {
            bgr.Clear(this.BackColor);
            if (mImage != null) bgr.DrawImage(mImage, 0, 0);
          }
          e.Graphics.DrawImage(bmp, 0, 0);
        }
        base.OnPaint(e);
      }
    }
