    public interface ITerrain
    {
        List<ITerrainPart> TerrainParts { get; }
        ITerrainPart CreateTerrainPart(int XSize, int ZSize, int XPosition, int ZPosition);
    }
    public interface ITerrainPart
    {
        // ...
    }
