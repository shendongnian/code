    public class Color
    {
        public static Color Black = new Color(0, 0, 0);
        public static Color White = new Color(255, 255, 255);
        public static Color Red   = new Color(255, 0, 0);
        public static Color Green = new Color(0, 255, 0);
        public static Color Blue  = new Color(0, 0, 255);
        private byte red, green, blue;
        public Color(byte r, byte g, byte b) => (red, green, blue) = (r, g, b);
    }
