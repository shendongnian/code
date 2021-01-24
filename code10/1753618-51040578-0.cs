    public class XZ
    {
        public int X { get; set; }
        public int Z { get; set; }
        public XZ(int x, int z)
        {
            X = x;
            Z = z;
        }
        public override string ToString()
        {
            return $"X = {X}, Z = {Z}";
        }
    }
