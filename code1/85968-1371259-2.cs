    private Terrain[,,] rawArray = ...;
    private View transformedArray = new View(rawArray);
    private class View
    {
        private Terrain[,,] array;
        public View(Terrain[,,] array)
        {
            this.array = array;
        }
        public Terrain this[int x, int y, int z]
        {
            get { ... }
            set
            {
                this.array[2*x, 3*z, -y] = value;
            }
        }
    }
