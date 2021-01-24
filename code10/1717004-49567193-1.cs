    [System.Serializable]
    public class Tile 
    {
       public Sprite tileSprite;
       public string tileName;
       public int tileID;
    
       public Tile(Sprite newTileSprite, string newTileName, int newTileID) 
       {
           tileSprite = newTileSprite;
           tileName = newTileName;
           tileID = newTileID;
       }
    }
