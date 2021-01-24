    public interface IAppPropertyService
    {
        IDictionary<string, object> Properties { get; set; }
    }
    
    public class AppPropertyService : IAppPropertyService
    {
        public const string AppPropertiesName = "AppProperties";
    
        public IDictionary<string, object> Properties { get; set; }
    
        public AppPropertyService([IocDepndancy(AppPropertiesName)] IDictionary<string, object> appProperties)
        {
            Properties = appProperties;
        }
    }
