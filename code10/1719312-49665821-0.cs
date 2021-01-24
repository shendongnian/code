       public class Unit
        {
            public static Dictionary<string, Unit> units { get; set; } // string is unit name
            public string name { get; set; }
            public int level { get; set; }
            public Dictionary<string, int> attributes { get; set; }
        }
