    public struct GridNeighbours {
        public enum Cardinal { North, East, South, West }
        public static Vector2Int[] Neighbours = { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(-1, 0) };
        public static Vector2Int North { get { return Neighbours[0]; } set { Neighbours[0] = value; } }
        public static Vector2Int East { get { return Neighbours[1]; } set { Neighbours[1] = value; } }
        public static Vector2Int South { get { return Neighbours[2]; } set { Neighbours[2] = value; } }
        public static Vector2Int West { get { return Neighbours[3]; } set { Neighbours[3] = value; } }
    }
