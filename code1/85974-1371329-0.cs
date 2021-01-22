    private Terrain[,,] rawArray = ...;
    private View view = new View(rawArray);
    
    private class View
    {
        private class TransformedView
        {
            private Terrain[,,] array;
            public TransformedView(Terrain[,,] array) 
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
 
        private Terrain[,,] array;
        public readonly TransformedView Transformed;
        public View(Terrain[,,] array)
        {
            this.array = array;
            Transformed = new TransformedView(array);
        }
        public Terrain this[int x, int y, int z]
        {
            get { ... }
            set
            {
                this.array[x, z, y] = value;
            }
        }
    }
