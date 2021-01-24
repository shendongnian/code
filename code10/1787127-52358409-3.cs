    // sealed: since we have 2 instances only we don't want to
    // inherit (and create) derived classes
    public sealed class UnitManager
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
    
        // private: since we have 2 intances only we don't want to expose the constructor
        private UnitManager(string name, string firstname)
        {
            this.Name = name;
            this.Firstname = firstname;
        }
    
        // Think over renaming of these fields: say, Player and Computer
        public static readonly UnitManager Player1 = new UnitManager("p1Name", "p1FirstName");
        public static readonly UnitManager Player2 = new UnitManager("p2Name", "p2FirstName");
    }
    
