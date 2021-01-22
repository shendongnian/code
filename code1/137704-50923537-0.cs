    public class Startup
    {
      public IServiceProvider ConfigureServices(IServiceCollection services)
      {
        services.AddMvc().AddJsonOptions(options =>
        {
          options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        });
      }
    }
