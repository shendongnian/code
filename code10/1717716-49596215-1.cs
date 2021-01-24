    GameSaved reloaded = new GameSaved();
    void Main()
    {
    	GameSaved game = new GameSaved();
    	game.Num_Of_Saved_Game = 2;
    	game.Name_Of_Saved_Game = new string[] {"game1", "game2"};
    	
    	Serialize(@"e:\temp\serialize.bin", game);
    	Deserialize(@"e:\temp\serialize.bin");
    	
    	Console.WriteLine("Games:" + reloaded.Num_Of_Saved_Game);
    	foreach(string s in reloaded.Name_Of_Saved_Game)
    		Console.WriteLine(s);
    }
    
    void Deserialize(string filename1)
    {
    	BinaryFormatter formatter = new BinaryFormatter();
    	using(FileStream fs = new FileStream(filename1, FileMode.Open, FileAccess.Read))
    		reloaded = (GameSaved)formatter.Deserialize(fs);
    }
    void Serialize(string filename1, GameSaved game)
    {
    	BinaryFormatter formatter = new BinaryFormatter();
    	using (FileStream fs = new FileStream(filename1, FileMode.OpenOrCreate, FileAccess.Write))
            formatter.Serialize(fs, game);
    	
    }
    [Serializable]
    struct GameSaved
    {
    	public int Num_Of_Saved_Game;
    	public string[] Name_Of_Saved_Game;
    }
