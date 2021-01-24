    public class HttpControllerSelector : IHttpControllerSelector
    {
        private readonly HttpConfiguration _httpConfiguration;
        public HttpControllerSelector(HttpConfiguration httpConfiguration)
        {
            this._httpConfiguration = httpConfiguration;
        }
        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            return new HttpControllerDescriptor(this._httpConfiguration, 
                                                nameof(ValuesController), 
                                                typeof(ValuesController));
        }
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            var mapping = new Dictionary<string, HttpControllerDescriptor>
            {
                {
                    nameof(ValuesController),
                    new HttpControllerDescriptor(this._httpConfiguration,
                                                 nameof(ValuesController),
                                                 typeof(ValuesController))
                }
            };
            return mapping;
        }
    }
