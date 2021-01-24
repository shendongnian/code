    [Serializable] public struct Location : IEquatable<Location>
    {
        public double X;
        public double Y;
        public double Z;
    
        public Location(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }
    
        public override string ToString() => $"{X}, {Y}, {Z}";
        public override bool Equals(object obj) =>
            obj is Location loc && Equals(loc);
        public bool Equals(Location other) =>
            X == other.X && Y == other.Y && Z == other.Z;
        public override int GetHashCode()
        {
            // Replace with whatever implementation you want
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            hash = hash * 23 + Z.GetHashCode();
            return hash;
        };
    }
