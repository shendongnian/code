    using (var client = new HttpClient())
    {
        List<string> param = new List<string>();
        param.Add(LblUnitsConsumed.Text);
        param.Add(LblUnitsRemaining.Text);
        param.Add(deviceIDtxt.Text);
    	
    	
        string jsonString = JsonConvert.SerializeObject(param);
        var requestUrl = new Uri(WebApiUrl + "/api/transaction/updateDevice/");
        using (HttpContent httpContent = new StringContent(jsonString))
        {
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PutAsync(requestUrl, httpContent).Result;
        }	
    }  
