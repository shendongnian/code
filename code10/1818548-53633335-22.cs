    public static JToken Concat(JToken jToken1, JToken jToken2)
    {
        int count1 = jToken1.Count();
        int count2 = jToken2.Count();
    
        JArray jArray = new JArray();
        for (int i = 0; i < count1 && count1 == count2; i++)
        {
            JObject jObject1 = (JObject)jToken1.ToObject<JArray>()[i];
            JObject jObject2 = (JObject)jToken2.ToObject<JArray>()[i];
    
            jObject1.Merge(jObject2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat });
            jArray.Add(jObject1);
        }
    
        return jArray;
    }
