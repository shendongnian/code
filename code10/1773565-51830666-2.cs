    public class Mountain : IBiome
    {
        private float[] _height = { 1f };
        public float[] height
        {
            get { return _height; }
        }
        private int[] _tiles = { Tile.Stone };
        public int[] tiles
        {
            get { return _tiles; }
        }
    }
