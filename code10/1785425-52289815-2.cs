        public Person HttpClientCall(Person value, string uri)
        {
            var client = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var httpresult = client.GetAsync(uri).Result;
            if (httpresult.IsSuccessStatusCode)
            {
                var result = httpresult.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Person>(result);
                return data
            }
            return new Person();
        }
