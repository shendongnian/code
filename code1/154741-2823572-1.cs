    static void Main(string[] args) 
    {
        Map myMap = new Map(); 
        myMap.Images = new List<byte[]>(); 
        myMap.Tiles = new List<Tile>(); 
 
        byte[] image = new byte[] { 1, 2, 3 }; 
        byte[] image2 = new byte[] { 10, 20, 30 }; 
        myMap.Add(image);
        myMap.Add(image2);
        
        byte[] image3 = new byte[] {100,200,255};
        myMap[0]=image3;
        
        printallmaps(myMap);
        myMap.Tiles.ForEach(c=>printall(c));
    } 
 
    public class Map 
    {
        public List<byte[]> Images  { get; set; } 
        public byte[] this[int i]
        {
            get
            {
                return Tiles[i].ImageData;
            }
            set
            {
                if(i >= this.Count)
                {
                    this.Insert(i,value);
                }
                else
                {
                    Tiles[i].ImageData = value;
                }
            }
        }
        public List<Tile> Tiles { get; set; }
        public int Count {get {return Tiles.Count;}}
        public void Add(byte[] image)
        {
            this[this.Count] = image;
        }
        public void Insert(int x, byte[] image)
        {
            Tile tile = new Tile();
            tile.ImageData = image;
            Tiles.Insert(x,tile);
        }
    } 
 
    public class Tile 
    { 
        public byte[] ImageData; 
        int x; 
        int y; 
    } 
