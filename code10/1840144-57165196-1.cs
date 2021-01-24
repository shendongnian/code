    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(GetConfiguration());
        }
        private IConfiguration GetConfiguration()
        {
            // Get the configuration from embedded dll.
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json"))
            using (var reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<IConfiguration>(reader.ReadToEnd());
            }
        }
