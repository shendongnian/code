    //This is abstract, no one can instantiate one, 
    //only subclasses of this type can be constructed
    public abstract class Transportation
    {
        //this is read-only and must be set at construction time
        public Terrain TerrainType { get; }
        protected Transportation(Terrain terrainType)
        {
            TerrainType = terrainType;
        }
        //you probably want some methods (example, Move).  You can declare them "abstract"
    }
