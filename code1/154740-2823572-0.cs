        static void Main(string[] args)
        {
            Map myMap = new Map();
            myMap.Images = new List<byte[]>();
            myMap.Tiles = new List<Tile>();
            byte[] image = new byte[] { 1, 2, 3 };
            byte[] image2 = new byte[] { 10, 20, 30 };
            myMap.Images.Add(image);
            myMap.Images.Add(image2);
            Tile myTile = new Tile();
            myTile.ImageData = myMap.Images[0];
            myMap.Tiles.Add(myTile);
            myTile = new Tile();
            myTile.ImageData = myMap.Images[1];
            myMap.Tiles.Add(myTile);
        }
        class Map
        {
            public List<byte[]> Images { get; set; }
            public List<Tile> Tiles { get; set; }
        }
        public class Tile
        {
            public byte[] ImageData;
            int x;
            int y;
        }
