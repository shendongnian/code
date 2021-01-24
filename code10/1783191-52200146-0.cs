    var ex_to_serialize = new Exception("something wrong", new NullReferenceException("set to null"));
    
    var serialized_ex = JsonConvert.SerializeObject(ex_to_serialize,new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All});
    
    var deserialized_ex = JsonConvert.DeserializeObject<Exception>(serialized_ex, new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All});
 
    Console.WriteLine($"Type of inner exception: {deserialized_ex.InnerException.GetType().Name}");
