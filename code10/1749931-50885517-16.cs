    class Drawing3D : Drawing2D
    {
        public Drawing3D(string name, int xPoint, int yPoint, int zPoint) : base(name, xPoint, yPoint)
        {
           Points.Add(new Point(zPoint, "Z"));
        }
    }
