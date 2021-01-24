    public class Dungeon : MonoBehaviour
    {
        public Tile[,] map = new Tile[40, 40];
    
        private void Start() 
        {
            for (int y = 0; y < 40; y++) 
            {
               for (int x = 0; x < 40; x++)
               {
                    map[x, y] = new Tile();
                    map[x, y].ceiling = 0;
                    map[x, y].northWall = 0;
                    map[x, y].westWall = 0;
                    map[x, y].floor = 0;
                }
            }
        }
    }
