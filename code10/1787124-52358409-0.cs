    public sealed class UnitManager
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
    
        private UnitManager(string name, string firstname)
        {
            this.Name = name;
            this.Firstname = firstname;
        }
    
        public static readonly UnitManager Player1 = new UnitManager("p1Name", "p1FirstName");
        public static readonly UnitManager Player2 = new UnitManager("p2Name", "p2FirstName");
    }
    
