    public static T Clone<T>(T toClone) where T : class
    {
            string tmp = Newtonsoft.Json.JsonConvert.SerializeObject(toClone,Formatting.None, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
            });
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tmp);
    }
