    if(env.IsDeveleopment())
    {
       loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Debug);
    }
    else if(env.IsPreProduction())
    {
       loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Verbose);
    
    }
    else
    {
       loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
    
    }
