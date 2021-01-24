    public async Task<Food> FoodCatalog(int category)
    {
    	string url = Service.baseURL + Service.FoodCatalog + "?category=" + category.ToString();
    	dynamic results = await Service.getDataFromService(url).ConfigureAwait(false);
    	string json = results as string;  // Otherwise error next line ???
    	var items = JsonConvert.DeserializeObject<List<Food>>(json);		
    	return items;
    }
