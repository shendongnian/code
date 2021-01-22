    /// <summary>
    /// Color that can be xml-serialized
    /// </summary>
    public class SerializableColor
    {
        public int A { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int KnownColor { get; set; }
        /// <summary>
        /// Intended for xml serialization purposes only
        /// </summary>
        private SerializableColor() { }
        public SerializableColor(Color color)
        {
            this.A = color.A;
            this.R = color.R;
            this.G = color.G;
            this.B = color.B;
            this.KnownColor = (int)color.ToKnownColor();
        }
        public static SerializableColor FromColor(Color color)
        {
            return new SerializableColor(color);
        }
        public Color ToColor()
        {
            if (KnownColor != 0)
            {
                return Color.FromKnownColor((KnownColor)KnownColor);
            }
            else
            {
                return Color.FromArgb(A, R, G, B);
            }
        }
    }
