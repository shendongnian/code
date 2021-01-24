    using (var client = new HttpClient())
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("username:password:camnamespace");
        var encodeData= System.Convert.ToBase64String(plainTextBytes);
   
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", "CAMNamespace "+ encodeData);
        //GET Method  
        HttpResponseMessage response = await client.GetAsync("http://serveraddress/api/v1/Cubes");
        if (response.IsSuccessStatusCode)
        {
            var det = await response.Content.ReadAsStringAsync();        
        }
        else
        {
            Console.WriteLine("Internal server Error");
        }
    }
