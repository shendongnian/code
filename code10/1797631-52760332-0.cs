        // 32 rows and 128 columns
        public static MapTile[,] map = new MapTile[32, 128];
        // Holds the character to be displayed and the colour to display it in
        public class MapTile
        {
            public char character {get; set;}
            public ConsoleColor colour { get; set; }
        }
