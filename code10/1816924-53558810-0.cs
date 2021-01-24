    public static JObject GetJObject(JObject jObject, List<string> optionType)
    {
        foreach (var type in jObject["OptionType"])
        {
            var key = type.ToObject<JProperty>().Name;
            var values = type.ToObject<JProperty>().Value.ToObject<List<string>>();
    
            foreach (var option in optionType)
            {
                if (values.Contains(option))
                {
                    int index = values.IndexOf(option);
                    values.RemoveAt(index);
                    values.Insert(index, key);
                }
            }
    
            JToken jToken = JToken.FromObject(values);
    
            jObject.SelectToken("OptionType." + key).Replace(jToken);
        }
    
        return jObject;
    }
