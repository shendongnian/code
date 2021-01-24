    public class CustomServiceFactory : ICustomServiceFactory
    {
        private readonly Dictionary<string, ICustomService> _services 
            = new Dictionary<string, ICustomService>(StringComparer.OrdinalIgnoreCase);
        public CustomServiceFactory(IServiceProvider serviceProvider)
        {
            _services.Add("TypeOne", serviceProvider.GetService<CustomServiceOne>());
            _services.Add("TypeTwo", serviceProvider.GetService<CustomServiceTwo>());
            _services.Add("TypeThree", serviceProvider.GetService<CustomServiceThree>());
        }
        
        public ICustomService Create(string input)
        {
            return _services.ContainsKey(input) ? _services[input] : _services["TypeOne"];
        }
    }
