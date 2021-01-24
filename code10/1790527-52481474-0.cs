     string json = JsonConvert.SerializeObject(abc);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("MyURL");  //==> I am filling it correctly
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            
            var stringContent = new StringContent(JsonConvert.SerializeObject(abc), Encoding.UTF8, "application/json"); 
            var response = client.PostAsync("MyURL", stringContent).Result; //==> I am filling my method correctly
