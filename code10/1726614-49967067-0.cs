    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var root = default(Rootobject);
        // Let's go through each tokenInfo and check if price is not false
        // so we can turn it into a dictionary.
        foreach (var thisToken in root.tokens)
        {
            if (thisToken.tokenInfo.price.ToString() != "false")
            {
                thisToken.tokenInfo.price = JsonConvert.DeserializeObject<Dictionary<string, string>>(thisToken.tokenInfo.price.ToString()); 
            }
        }
            
        serializer.Populate(jsonObject.CreateReader(), root);
        return root;
    }
