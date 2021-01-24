    public async Task<RootObject> GetVehiclesAsync()
        {
            RootObject rootObject = null;
            var client = new HttpClient();
            string restUrl = "https://www.foo.com/vehicle/api/";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObject>(content);
            }
            return rootObject;
        }
    RootObject Root = await GetVehiclesAsync();
    foreach (var item in Root.Value)
    {
         // Do something here
         // item.Model
         // item.Description
         // item.ETag
    }
