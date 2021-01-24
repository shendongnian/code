       var dj = new Dj() { Name = "Tim", Label = "UMG", StageName = "Avicii" };
        var obj = new 
        {
            Dj = dj
        };
    
                var eventModelsSerialized = JsonConvert.SerializeObject(obj, Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       TypeNameHandling = TypeNameHandling.Auto
                   });
