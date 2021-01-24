    public static JToken Concat(JToken jToken1, JToken jToken2)
    {
        JArray jArray = new JArray();
    
        foreach (JObject jObject1 in jToken1.ToObject<JArray>())
        {
            var value = jObject1.Properties().Where(x => x.Name == "SRL_NUM").FirstOrDefault().Value;
    
            var result = jToken2.ToObject<JArray>().ToObject<JObject[]>().Properties().Where(x => x.Name == "SRL_NUM" && Convert.ToInt32(x.Value) == Convert.ToInt32(value)).Select(x => x.Parent);
    
            JArray jAr = new JArray();
    
            foreach (JObject obj in result)
            {
                jAr.Add(obj);
            }
    
            JObject jObject = new JObject();
    
            jObject.Merge(jObject1, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat });
            jObject.Add("Data", jAr);
    
            jArray.Add(jObject);
        }
    
        return jArray;
    }
