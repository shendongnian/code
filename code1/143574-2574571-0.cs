    using (Bitmap bitmap = new Bitmap(20, 20))
    {
       using (Graphics g = Graphics.FromImage(bitmap))
       {
          using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#ff00ffff")))
          {
             g.FillEllipse(b, 0, 0, 19, 19);
          }
       }
    }
