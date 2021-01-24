    public class Dungeon : MonoBehaviour
    {
        public Tile[,] map = new Tile[40, 40];
    
        private void Start() 
        {
            for (int y = 0; y < 40; y++) 
            {
                for (int x = 0; x < 40; x++)
                {
                    Tile[x, y] = new Tile(0,0,0,0);
                }
            }
        }
    }
