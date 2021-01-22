    [System.ComponentModel.DesignerCategory("")]
    public class AutoScaleButton : Button
    {
      private Image _AutoScaleImage;
      public Image AutoScaleImage {
        get { return _AutoScaleImage; }
        set {
          _AutoScaleImage = value;
          if (value != null)
            this.Invalidate();
        }
      }
      private int _AutoScaleBorder;
      public int AutoScaleBorder {
        get { return _AutoScaleBorder; }
        set {
          _AutoScaleBorder = value;
          this.Invalidate();
        }
      }
      protected override void OnPaint(PaintEventArgs e)
      {
        base.OnPaint(e);
        DrawResizeImage(ref e.Graphics);
      }
      private void DrawResizeImage(ref Graphics g)
      {
        if (_AutoScaleImage == null)
          return;
        int iB = AutoScaleBorder;
        int iOff = 0;
        Rectangle rectLoc = default(Rectangle);
        Rectangle rectSrc = default(Rectangle);
        Size sizeDst = new Size(Math.Max(0, this.Width - 2 * iB), 
              Math.Max(0, this.Height - 2 * iB));
        Size sizeSrc = new Size(_AutoScaleImage.Width, 
              _AutoScaleImage.Height);
        double ratioDst = sizeDst.Height / sizeDst.Width;
        double ratioSrc = sizeSrc.Height / sizeSrc.Width;
        rectSrc = new Rectangle(0, 0, sizeSrc.Width, sizeSrc.Height);
        if (ratioDst < ratioSrc) {
          iOff = (sizeDst.Width - 
            (sizeDst.Height * sizeSrc.Width / sizeSrc.Height)) / 2;
          rectLoc = new Rectangle(iB + iOff, 
                iB, 
                sizeDst.Height * sizeSrc.Width / sizeSrc.Height, 
                sizeDst.Height);
        } else {
          iOff = (sizeDst.Height - (sizeDst.Width * sizeSrc.Height / sizeSrc.Width)) / 2;
          rectLoc = new Rectangle(iB, 
                iB + iOff, 
                sizeDst.Width, 
                sizeDst.Width * sizeSrc.Height / sizeSrc.Width);
        }
        g.DrawImage(_AutoScaleImage, rectLoc, rectSrc, GraphicsUnit.Pixel);
      }
    }
    
