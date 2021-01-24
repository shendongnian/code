    public static class Rest {
        static Lazy<RestClient> client = new Lazy<RestClient>(() => {
            var endpoint = "webservice.php";
            var endPointUrl = baseUrl + endpoint;    
            var client = new RestClient(endPointUrl);
            client.CookieContainer = new System.Net.CookieContainer();
            return client
        });
    
        public static RestClient Client {
            get {
                return client.Value;
            }
        }
    }
