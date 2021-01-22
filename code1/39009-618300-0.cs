    void RemTransp(string file) {
        Bitmap src = new Bitmap(file);
        Bitmap target = new Bitmap(src.Size.Width,src.Size.Height);
        Graphics g = Graphics.FromImage(target);
        g.DrawRectangle(new Pen(new SolidBrush(Color.White)), 0, 0, target.Width, target.Height);
        g.DrawImage(src, 0, 0);
        target.Save("Your target path");
    }
