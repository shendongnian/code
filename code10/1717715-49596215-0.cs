    void Serialize(string filename1, GameSaved game)
    {
    	BinaryFormatter formatter = new BinaryFormatter();
    	using (FileStream fs = new FileStream(filename1, FileMode.OpenOrCreate, FileAccess.Write))
    	{
    		formatter.Serialize(fs, game);
    	}
    }
