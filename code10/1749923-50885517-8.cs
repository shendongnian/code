    class Drawing2D : Drawing
    {
        public Drawing2D(string name, int xPoint, int yPoint) : base (name)
        {
            Points.Add(new Point(xPoint, "X"));
            Points.Add(new Point(yPoint, "Y"));
        }
    }
