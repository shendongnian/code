    public class Dungeon : MonoBehaviour
    {
        public Tile[,] map = new Tile[40, 40];
    
        private void Start() 
        {
            for (int y = 0; y < 40; y++) 
            {
               for (int x = 0; x < 40; x++)
               {
                    // For simple types like e.g. int, string etc there are default values
                    // so the array would be filled with those values.
                    // However your class Tile has the default value null
                    // So you have to create Tile instances using the default constructor like
                    map[x, y] = new Tile();
                    // And than optionally give it values
                    // though they will be 0 by default of course
                    map[x, y].ceiling = 0;
                    map[x, y].northWall = 0;
                    map[x, y].westWall = 0;
                    map[x, y].floor = 0;
                    // or alternatively
                    map[x, y] = new Tile()
                        {
                            ceiling = 0,
                            northWall = 0,
                            westWall = 0,
                            floor = 0
                        };
                }
            }
        }
    }
