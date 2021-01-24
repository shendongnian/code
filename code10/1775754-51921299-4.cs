    private List<WebsiteItemViewModel> readData()
    {
    	string data = File.ReadAllText("Testfile");
    	return JsonConvert.DeserializeObject<List<WebsiteItemViewModel>>(data);
    }
    
