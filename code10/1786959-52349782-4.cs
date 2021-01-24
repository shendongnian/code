    private void timer_Tick(object sender, EventArgs e)
    {
       if (NewZoomLocation)
       {
          var w = _lastBmp.Size.Width / zoom;
          var h = _lastBmp.Size.Height / zoom;
          var x = _position.X - w / 2;
          var y = _position.Y - h / 2;
          var size = new Size(w, h);    
          using (var screen = new Bitmap(size.Width, size.Height))
          {
             using (var g = Graphics.FromImage(screen))
             {
                g.CopyFromScreen(new Point(x, y), Point.Empty, size);
             }
             // resize
             using (var g = Graphics.FromImage(_lastBmp))
             {
                g.DrawImage(screen, new Rectangle(new Point(), _lastBmp.Size), new Rectangle(0, 0, w, h), GraphicsUnit.Pixel);
             }
          }
    
          pictureBox1.Image = _lastBmp;
       }
    }
