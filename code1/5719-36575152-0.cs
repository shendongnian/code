    private static MyObj DeepCopy(MyObj source)
            {
               
                var DeserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
    
                return JsonConvert.DeserializeObject<MyObj >(JsonConvert.SerializeObject(source), DeserializeSettings);
    
            }
