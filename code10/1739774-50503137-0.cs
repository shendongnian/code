    abstract class Figure
    {
        public abstract void Draw(Graphics graphics);
    }
    class Convex: Figure
    {
        public List<Point> Points { get; set; }
        public Color Color { get; set; } = Color.Black;
        ... // more properties
        public override void Draw(Graphics graphics) 
        {
            if(Points != null)
                using(var pen = new Pen(Color))
                    graphics.DrawLines(pen, Points.ToArray());
        }
    }
    ... // more figures
