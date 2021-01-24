    public class ChartConfiguration: IChartConfiguration
    {
        public Scrumban Scrumban { get; }
        public ChartConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            Scrumban = new Scrumban();
            configuration.GetSection("Scrumban").Bind(Scrumban);
        }
    }
