    public async Task<StrongType> GetAsync(Item item)
    {
        var response = await Client.GetAsync(item);
        var body = await response.Content.ReadAsStringAsync();  
          
        return JsonConvert.DeserializeObject<StrongType>(body);
    }
    public async Task Run(IEnumerable<Item> items)
    {
        var tasks = items.Select(item => GetAsync(item));
        await Task.WhenAll(tasks);
        var loadedStrongTypes = tasks.Select(task => task.Result);
        dbContext.AddRange(loadedStrongTypes);
    }
