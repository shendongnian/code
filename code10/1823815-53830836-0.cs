    // ListView A (Source)
    // when ItemSelected is processed this function is called
    
    public void AddToHistory(Object obj)
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "history.txt");
    	var _tempList = new List<Object>();
    	if (File.Exist(fileName) 
    	{
    		var _tempContent = File.ReadAllText(fileName);
    		var json = JsonConvert.DeserializeObject<List<Object>>(tempContent);
    		_tempList.AddRang(json);
    		_tempList.Add(obj);
    	} else 
    	{
    		_tempList.Add(obj);
    	}
        var content = JsonConvert.SerializeObject(_tempList);
        File.WriteAllText(fileName, content);
    }
    
    // ListView B (Destination View)
    void CreateListOfObjects()
    {
        ObjectList = new List<Object>();
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "history.txt");
        var content = File.ReadAllText(fileName);
        var json = JsonConvert.DeserializeObject<List<Object>>(content);
        ObjectList.AddRange(json);
    }
