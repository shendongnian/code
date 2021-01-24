    private class Terrain : ITerrain
    {
        int XPosition;
        int ZPosition;
        public List<ITerrainPart> TerrainParts { get; }  = new List<ITerrainPart>();
        public Terrain(int XPosition, int ZPosition)
        {
            this.XPosition = XPosition; this.ZPosition = ZPosition;
        }
        public ITerrainPart CreateTerrainPart(int XSize, int ZSize, int XPosition,
                                              int ZPosition)
        {
            return new TerrainPart(XSize, ZSize, ZPosition, ZPosition);
        }
        private class TerrainPart : ITerrainPart
        {
            // ...
        }
    }
