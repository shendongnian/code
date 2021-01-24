    List<ResourceCollection> liResourceName = new List<ResourceCollection>();
    liResourceName.Add(new ResourceCollection { Name = "Hello", Resources = new Resources { en = "Hello" } });
    liResourceName.Add(new ResourceCollection { Name = "World", Resources = new Resources { en = "World" } });
    var formating = Newtonsoft.Json.Formatting.Indented;
    var converter = new ResourceCollectionConverter();
    string json = JsonConvert.SerializeObject(liResourceName, formating , converter);
        
