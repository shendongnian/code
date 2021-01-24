    public class DataProvider<T> where T : class
    {
        private readonly IService<T> _service;
        public DataProvider(IService<T> service) => _service = service;
        public IQueryable<T> List(HttpRequestMessage request)
        {
            var queryString = request.GetQueryNameValuePairs();
            var models = _service.List();
            foreach (var item in queryString)
            {
                var query = $"{ item.Key }.ToString().Contains(\"{ item.Value }\")";
                models = models.Where(query);
            }
            return models;
        }
    }
