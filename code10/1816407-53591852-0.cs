        private HttpClient _simpleserviceClient;
		
		private const string _getUri = "/ROUTE_TO_ACTION/{0}";
		private const string _postUri = "/ROUTE_TO_ACTION";
        
        public ReturnModel Postdata(SomeModel model)
        {
            var uri = string.Format(_postUri );
            var response = ServiceClient().PostAsJsonAsync(uri, model).Result;
            var result = response.Content.ReadAsAsync<ReturnModel>().Result;
            return result;
        }
		
		public ReturnModel getdata(int id)
        {
            var uri = string.Format(_getUri ,id);
            var response = ServiceClient().GetAsync(uri).Result;
            var result = response.Content.ReadAsAsync<ReturnModel>().Result;
            return result;
        }
		
		private HttpClient ServiceClient()
		{
			var client= _simpleserviceClient ?? new HttpClient();
			client.BaseAddress = new Uri("YOUR_BASE_URL_TO_API");   //"http://localhost:8080/"
            client.Timeout = TimeSpan.FromMinutes(3);
		}
