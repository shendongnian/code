        var settings = new JsonSerializerSettings
        {
            Converters = { new LikeTypeConverter() },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        var result = JsonConvert.SerializeObject(myObject, Formatting.Indented, settings);
