        public class Provider
        {
            public bool IsDefaultProvider { get; set; }
            public string Name { get; set; }
            public string BaseUrl { get; set; }
            public string ApiKey { get; set; }
            public string SecretKey { get; set; }
        }
        public class X
        {
            public List<Provider> Providers { get; set; }
        }
