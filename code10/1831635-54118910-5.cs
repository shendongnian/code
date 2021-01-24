    public class JSON_Logs
    {
        public class Header
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string format { get; set; }
            public string resourceId { get; set; }
            public int deckTileId { get; set; }
            public MainDeck[] mainDeck { get; set; }
            public object[] sideboard { get; set; }
            public DateTime lastUpdated { get; set; }
            public bool lockedForUse { get; set; }
            public bool lockedForEdit { get; set; }
            public bool isValid { get; set; }
        }
        public class MainDeck
        {
            public string id { get; set; }
            public int quantity { get; set; }
        }
    }
