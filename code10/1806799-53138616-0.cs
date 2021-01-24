    [Serializable]
    public class WorldState
    {
        public short[,] Items { get; set; }
        public void Save(string filename)
        {
            if (filename == null) throw new ArgumentNullException(nameof(filename));
            using (var file = File.Create(filename))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(file, this);
            }
        }
        public static WorldState Load(string filename)
        {
            if (filename == null) throw new ArgumentNullException(nameof(filename));
            if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);
            using (var file = File.OpenRead(filename))
            {
                var serializer = new BinaryFormatter();
                return serializer.Deserialize(file) as WorldState;
            }
        }
    }
	
	public class WorldStateTests
    {
        [Fact]
        public void CanSaveAndLoad()
        {
            var ws = new WorldState
            {
                Items = new short[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 4 }
                }
            };
            // save the world state to file. Find it and see what's inside 
            ws.Save("./ws.bin");
            
            // load the world back
            var loaded = WorldState.Load("./ws.bin");
            // check a new world state got loaded
            Assert.NotNull(loaded);
            // and it still has items
            Assert.NotEmpty(loaded.Items);
            // and the items are the same as we saved
            Assert.Equal(ws.Items, loaded.Items);
        }
    }
