        public class BlahValueProvider : IValueProvider
    {
        private readonly string _requestBody;
        public BlahValueProvider(string requestBody)
        {
            _requestBody = requestBody;
        }
        private const string PROPERTY_NAME = "WhatType";
        
        public bool ContainsPrefix(string prefix)
        {
            return prefix == PROPERTY_NAME;
        }
        public ValueProviderResult GetValue(string key)
        {
            if (key != PROPERTY_NAME)
                return ValueProviderResult.None;
            
            // parse json
            try
            {
                var json = JObject.Parse(_requestBody);
                return new ValueProviderResult(json.Value<int>("WhatType").ToString());
            }
            catch (Exception e)
            {
                // TODO: error handling
                throw;
            }
        }
    }
    public class BlahValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var request = context.ActionContext.HttpContext.Request;
            if (request.ContentType == "application/json")
            {
                return AddValueProviderAsync(context);
            }
            return Task.CompletedTask;
        }
        private Task AddValueProviderAsync(ValueProviderFactoryContext context)
        {
            using (StreamReader sr = new StreamReader(context.ActionContext.HttpContext.Request.Body))
            {
                string bodyString = sr.ReadToEnd();
                context.ValueProviders.Add(new BlahValueProvider(bodyString));
            }
            return Task.CompletedTask;
        }
    }
