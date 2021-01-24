    public void ConfigureServices(IServiceCollection services)
    {
        try
        {
            //..other codes
            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
            });
        }
        catch (Exception ex)
        {
            string innerMessage = "";
            if (ex.InnerException != null)
                innerMessage = ex.InnerException.Message;
            Log.Logger.Error("ConfigureServices Message: " + ex.Message + " inner Message:" + innerMessage + "Env.Name:" + _env.EnvironmentName);
        }
    }
