    public class WorldManager : MonoBehaviour {
        // Being cheap here for the time, if you use this route make sure to use a proper singleton pattern
        static public WorldManager instance; 
        [SerializeField]  // Created a prefab for all my tile objects
        private TileObject tilePrefab; 
        [SerializeField]
        private int StartingTilePool = 300;
        [SerializeField] // In my case this list stored 1 sprite, and I just changed that sprite color depending on the value of perlin noise
        List<Sprite> terrainSprites; 
        
        private Queue<TileObject> objectPool = new Queue<TileObject>();
        
        void Start() {
            instance = this; // Again use a proper singleton pattern in your project.
            GenerateTilePool();
            LoadFirstSetOfTiles();
        }
        
        private void LoadFirstSetOfTiles()
        {
            // my player always starts at 0,0..
            for(int x = -SpawnTileBoundry.HorizontalExtents; x <= SpawnTileBoundry.HorizontalExtents; ++x) 
            {
                 for(int y = -SpawnTileBoundry.VerticalExtents; y <= SpawnTileBoundry.VerticalExtents; ++y) 
                 {
                     SetActiveTile(x,y);
                 }
            }
        }
        private void GenerateTilePool()
        {
            for(int i =0; i < tilesToGenerate; ++i)
            {
                TileObject tempTile = Instantiate(tilePrefab);
                EnqueTile(tempTile);
            }
        }
        public void EnqueTile(TileObject tile)
        {
            objectPool.Enqueue(tile);
            tile.gameObject.SetActive(false);
        }
        public void SetActiveTile(int x, int y)
        {
            TileObject newTile = null;
            if(objectPool.count > 0)
            {
                newTile = objectPool.Dequeue();
            }
            else
            {
                // We didn't have enough tiles store in our pool so lets make a new 1.
                newTile = Instantiate(tilePrefab);
            }         
            newTile.transform.position = new Vector3(x,y,1); // Used 1 to put it behind my player...
            newTile.gameObject.SetActive(true);
            // The sprite here would be based off of your world data, where mine is only a white box, I use the second parameters to give it a gray-scaled color.
            newTile.UpdateSprite(terrainSprites[0], Mathf.PerlinNoise(x/10.0f, y / 10.0f));
        }
    }
