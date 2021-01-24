    public class Game
    {
        public string SnapshotJson { get; set; }
    
        private void LoadGameData()
        {
            // load the json, e.g. by deserialization
            SnapshotJson = "{}";
        }
    
        public void Start()
        {
            // access the content of your snapshot
            var s = SnapshotJson;
        }
    
    }
