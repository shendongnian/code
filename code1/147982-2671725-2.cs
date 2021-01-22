    PointF[] pts = new PointF[] { 
        new PointF(100f, 100f), new PointF(300f, 200f), 
        new PointF(500f, 200f), new PointF(300f, 500f), 
        new PointF(600f, 450f), new PointF(650f, 180f), 
        new PointF(800f, 180f), new PointF(800f, 500f), 
        new PointF(200f, 700f)
    };
    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    using(Graphics g = Graphics.FromImage(pictureBox1.Image)){
        g.DrawLines(new Pen(Color.Red), pts);
        foreach (PointF[] line in MultiplyLine(pts, 80, 14))
            g.DrawLines(new Pen(Color.Black), line);
    }
