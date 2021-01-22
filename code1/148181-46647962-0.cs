    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    ServicePointManager.ServerCertificateValidationCallback +=
        (sender, cert, chain, sslPolicyErrors) => { return true; };
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(UserDataUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new
          MediaTypeWithQualityHeaderValue("application/json"));
        Task<string> response = client.GetStringAsync(UserDataUrl);
        response.Wait();
     
        if (response.Exception != null)
        {
             return null;
        }
     
        return JsonConvert.DeserializeObject<UserData>(response.Result);
    }
