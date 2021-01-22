    private Update BuildMetaData(NameValueCollection nvPairs)
    {
        Update update = new Update();
        update.Items = nvPairs.Keys
            .Select(k=> new InputProperty
                        {
                           Name = "udf:" + k,
                           Val = nvPairs[k] // or Values = nvPairs.GetValues(k)
                        }
             )
            .ToArray();
        return update;      // return the Update object
    }
