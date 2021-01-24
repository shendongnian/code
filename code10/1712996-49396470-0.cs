    [Serializable]
    public class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ShapeType ShapeType { get; set; }
        public Color Color { get; set; }
        public bool Mirrored { get; set; }
    }
