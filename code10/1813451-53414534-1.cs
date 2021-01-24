    static void Main(string[] args)
            {
    
                var deserializer = new DeserializerBuilder()
                   .WithNamingConvention(new CamelCaseNamingConvention())
                   .Build();
    
                var object1 = deserializer.Deserialize<Dictionary<string,object>>(@"---
    first_name: ""John""
    last_name: ""Smith""
    enabled: false
    roles:
        - user
    ...");
    
                var object2 = deserializer.Deserialize<Dictionary<string, object>>(@"---
    enabled: true
    roles:
      - user
      - admin
    ...");
                foreach (var tuple in object2)
                {
                    if (!object1.ContainsKey(tuple.Key))
                    {
                        object1.Add(tuple.Key, tuple.Value);
                        continue;
                    }
    
                    var oldValue = object1[tuple.Key];
                    if (!(oldValue is ICollection))
                    {
                        object1[tuple.Key] = tuple.Value;
                        continue;
                    }
    
    
                    //Merge collection
                    var mergeCollection = new HashSet<object>(oldValue as IEnumerable<object>);
                    if (!(tuple.Value is ICollection))
                        mergeCollection.Add(tuple.Value);
                    else
                    {
                        foreach (var item in tuple.Value as IEnumerable)
                        {
                            mergeCollection.Add(item);
                        }
                    }
    
                    object1[tuple.Key] = mergeCollection;                                                             
    
                }
    
                var result = new SerializerBuilder().Build().Serialize(object1);
    
            }
    
