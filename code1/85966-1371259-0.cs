    public class TerrainArray
    {
        public Terrain this[int x, int y, int z]
        {
            get { ... }
            set
            {
                this.array[2*x, 3*z, -y] = value;
            }
        }
    }
