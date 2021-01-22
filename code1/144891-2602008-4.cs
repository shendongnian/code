    class Coordinate{
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinate(int x, int y){
            X = x;
            Y = y;
        }
        public static FromString(string coord){
            try
            {
                // Parse comma delimited integers
                int[] coords = coord.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
                return new Coordinate(coords[0], coords[1]);
            }
            catch
            {
                // Some defined default value, if the format was incorrect
                return new Coordinate(0, 0);
            }
        }
    }
