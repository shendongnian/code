    void Awake() {
        //this is an object initializer, pass your Game[] in place of this
        Save(new[] {
            new Game { propertyStub = 0 },
            new Game { propertyStub = 1 },
            new Game { propertyStub = 2 }
        });
    
        var gA = Load();
        if(gA == null || gA.Length > 3) throw new SerializationException("Serialize error");
    
        foreach (var g in gA) Debug.Log(g);
    }
    
    public static void Save(Game[] gA) {
        using (var f = File.Create(Directory.GetCurrentDirectory() + "\\sample.bin")) new BinaryFormatter().Serialize(f, gA);
    }
    
    public static Game[] Load() {
        using (var f = File.Open(Directory.GetCurrentDirectory() + "\\sample.bin", FileMode.Open)) return (new BinaryFormatter().Deserialize(f)) as Game[];
    }
    //Stub class used for testing purposes
    [Serializable]
    class Game {
        public int propertyStub { get; set; }
        public override string ToString() {
            return "propertyStub value: " + propertyStub;
        }
    }
