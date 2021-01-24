    var settings = new JsonSerializerSettings
    {
        //Commented out TypeNameHandling since the JSON in the question does not include type information
        //TypeNameHandling = TypeNameHandling.All,
        NullValueHandling = NullValueHandling.Ignore,
        FloatParseHandling = FloatParseHandling.Decimal,
        Formatting = Formatting.Indented,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        ReferenceResolverProvider = () => new SelectiveValueEqualityReferenceResolver(
            new JsonSerializer().ReferenceResolver, 
            new [] { typeof(EntityA), typeof(EntityB) }),
        Error = (sender, args) => Log.Error(args.ErrorContext.Error, $"Error while (de)serializing: {args.ErrorContext}; object: {args.CurrentObject}")
    };
    var outer = JsonConvert.DeserializeObject<OuterClass>(jsonString, settings);
    var json2 = JsonConvert.SerializeObject(outer, settings);
