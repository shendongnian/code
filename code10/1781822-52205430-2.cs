     class Room
    {
        public int ID;
        public string Name;
        public int Completed = 0;
        public Random r = new Random();
        public static Random r1 = new Random();
        
        public int North;
        public int East;
        public int South;
        public int West;
        public Room(int id, string name, int north, int east, int south, int west)
        {
            this.ID = id;
            this.Name = name;
            this.North = north;
            this.East = east;
            this.South = south;
            this.West = west;
        }
