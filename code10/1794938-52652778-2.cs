    using (var client = new HttpClient())
    {
    	var response = await client.PostAsync("http://192.168.1.15:8282/api/Customers",new StringContent("=Mystring", Encoding.UTF8, "application/x-www-form-urlencoded"));
    
    	if (response.IsSuccessStatusCode)
    	{
    		string content = await response.Content.ReadAsStringAsync();
    	}
    }
