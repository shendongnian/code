    public void ConfigureServices(IServiceCollection services)
    {
      //add to beginning of the method... 
      services.Configure<FormOptions>(x =>
      {
          x.ValueLengthLimit = int.MaxValue;
          x.MultipartBodyLengthLimit = int.MaxValue;
          x.MultipartHeadersLengthLimit = int.MaxValue;
      });
    
       
    }
