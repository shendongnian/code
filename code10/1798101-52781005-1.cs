    public class Map{
        public char[][] TileMap;
        public int Height, Width;
        public Map(){
            TileMap = new char[16][16];  //Default to a 16x16 map
            Height = 16;
            Width = 16;
        }
        public Map(string file){
            //Load the map like you did above, but store the chars read into the TileMap array
            //Give the 'Height' and 'Width' fields the height and width of the map
        }
        
        public void Update(){
            //Call this AFTER Player.Update()
            
            //Use the reference map to add the correct tile to the previous position
            //and then update the Player's icon
            TileMap[Player.PrevX][Player.PrevY] = RPG.ReferenceMap.TileMap[Player.PrevX][Player.PrevY];
            
            TileMap[Player.X][Player.Y] = 'O';  //Assuming that 'O' is your player icon
        }
        
        public void Draw(){
            //Use the "TileMap" field to refresh the map
            
            Console.Clear();  //Clear the console
            foreach(char[] array in TileMap){
                foreach(char tile in array){
                    //Use the logic you used in your "foreach" loop to draw the tiles.
                }
            }
        }
    }
