    public static Bitmap cropAtRect(this Bitmap b, Rectangle r)
    {
      Bitmap nb = new Bitmap(r.Width, r.Height);
      Graphics g = Graphics.FromImage(nb); g.DrawImage(b, -r.X, -r.Y);
      return nb;
    }
