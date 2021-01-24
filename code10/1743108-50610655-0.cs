    services.AddMvc()
    .AddJsonOptions(opt =>
    {
        if (opt.SerializerSettings != null)
        {
                opt.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto,
                opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore,
                opt.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore
        }
    });
