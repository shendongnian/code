    public T Clone(T obj)
    {
     JsonSerializerSettings jss = new JsonSerializerSettings {
      ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
      Formatting = Formatting.Indented
     };
    
     var json = JsonConvert.SerializeObject(obj, jss);
     return JsonConvert.DeserializeObject<T>(json);
    }
