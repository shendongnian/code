    // Immutable implementation of ISize
    public class FixedSize : ISize
    {
        public static readonly FixedSize Preview = new FixedSize(200, 160);
        private readonly int width;
        private readonly int height;
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public FixedSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
