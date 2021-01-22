    public class MockHttpApplicationState : HttpApplicationStateBase
    {
        private IDictionary<string, object> _appState = new Dictionary<string, object>();
        public override void Add(string name, object value)
        {
            _appState.Add(name, value);
        }
        public override object Get(string name)
        {
            return _appState[name];
        }
        public override object this[string name]
        {
            get
            {
                return _appState[name];
            }
            set
            {
                _appState[name] = value;
            }
        }
    }
    public class MockHttpContext : HttpContextBase
    {
        private IDictionary<string, object> _appKeys;
        public MockHttpContext()
        {
        }
        /// <summary>
        /// Accepts a dictionary of app keys to supply to the HttpApplicationState instance
        /// </summary>
        /// <param name="applicationState"></param>
        public MockHttpContext(IDictionary<string,object> applicationState)
        {
            _appKeys = applicationState;
        }
        public override Cache Cache
        {
            get
            {                
                return HttpRuntime.Cache;
            }
        }
        public override HttpApplicationStateBase Application
        {
            get
            {
                var mockAppState = new MockHttpApplicationState();
                foreach (string key in _appKeys.Keys)
                {
                    mockAppState.Add(key, _appKeys[key]);
                }
                return mockAppState;
            }
        }
        public override HttpRequestBase Request
        {
            get
            {
                return new HttpRequestWrapper(new HttpRequest(null,"http://localhost",null));
            }
        }
    }
