    using (var client = new WebClient())
    {
        client.Headers["Content-Type"] = "application/json; charset=utf-8";
        var requestBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(myObj));
        var response = webClient.UploadData(targetUrl, callMethod, requestBody);
    }
