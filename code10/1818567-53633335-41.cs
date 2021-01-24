    public static JToken Concat(JToken jToken1, JToken jToken2)
    {
        JArray jArray = new JArray();
        foreach (JObject jObject1 in jToken1.ToObject<JArray>())
        {
            var value1 = jObject1.Properties().Where(x => x.Name == "SRL_NUM").FirstOrDefault().Value;
            foreach (JObject jObject2 in jToken2.ToObject<JArray>())
            {
                var value2 = jObject2.Properties().Where(x => x.Name == "SRL_NUM").FirstOrDefault().Value;
                if (Convert.ToInt32(value1) == Convert.ToInt32(value2))
                {
                    jObject1.Merge(jObject2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat });
                    jArray.Add(jObject1);
                }
            }
        }
        return jArray;
    }
