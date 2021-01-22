    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MyButton : Button {
      protected override void OnSizeChanged(EventArgs e) {
        base.OnSizeChanged(e);
        Bitmap bmp = new Bitmap(this.Width, this.Height);
        using (Graphics gr = Graphics.FromImage(bmp)) {
          ButtonRenderer.DrawButton(gr,
            new Rectangle(0, 0, bmp.Width, bmp.Height),
            System.Windows.Forms.VisualStyles.PushButtonState.Normal);
        }
        if (this.BackgroundImage != null) this.BackgroundImage.Dispose();
        this.BackgroundImage = bmp;
      }
    }
