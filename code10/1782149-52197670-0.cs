    public struct GridNeighbours {
        public enum Cardinal { North, East, South, West }
        public static Vector2Int[] Neighbours = { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(-1, 0) };
        public Vector2Int this[Cardinal dirn] {
            get { return this[(int)dirn]; }
            set { this[(int)dirn] = value; }
        }
        public Vector2Int this[int dirn] {
            get { return Neighbours[dirn]; }
            set { Neighbours[dirn] = value; }
        }
    }
