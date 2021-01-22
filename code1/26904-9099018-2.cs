    public struct Colors
    {
        private String current;
        private static string red = "#ff0000";
        private static string green = "#00ff00";
        private static string blue = "#0000ff";
        private static IList<String> possibleColors; 
        public static Colors Red { get { return (Colors) red; } }
        public static Colors Green { get { return (Colors) green; } }
        public static Colors Blue { get { return (Colors) blue; } }
        static Colors()
        {
            possibleColors = new List<string>() {red, green, blue};
        }
        public static explicit operator String(Colors value)
        {
            return value.current;
        }
        public static explicit operator Colors(String value)
        {
            if (!possibleColors.Contains(value))
            {
                throw new InvalidCastException();
            }
            
            Colors color = new Colors();
            color.current = value;
            return color;
        }
        public static bool operator ==(Colors left, Colors right)
        {
            return left.current == right.current;
        }
        public static bool operator !=(Colors left, Colors right)
        {
            return left.current != right.current;
        }
        public bool Equals(Colors other)
        {
            return Equals(other.current, current);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Colors)) return false;
            return Equals((Colors)obj);
        }
        public override int GetHashCode()
        {
            return (current != null ? current.GetHashCode() : 0);
        }
        public override string ToString()
        {
            return current;
        }
    }
