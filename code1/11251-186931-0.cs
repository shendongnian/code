    HttpClient client = new HttpClient();
    var checkingResponse = await client.GetAsync(url);
    if (!checkingResponse.IsSuccessStatusCode)
    {
       return false;
    }
