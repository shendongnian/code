    HttpClient client = new HttpClient();       
    client.BaseAddress = new Uri(whatever  your url);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    return client;
