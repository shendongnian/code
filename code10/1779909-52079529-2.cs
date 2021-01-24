    services.AddMvc(options =>
    {
        options.Filters.Add<GeneralExceptionFilter>();
        options.Filters.Add<DbExceptionFilter>();
    });
