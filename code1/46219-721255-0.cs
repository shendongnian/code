    public struct Direction
    {
        public int Azimuth { get; private set; }
        public Direction(int azimuth) : this()
        {
            Azimuth = azimuth;
        }
    }
