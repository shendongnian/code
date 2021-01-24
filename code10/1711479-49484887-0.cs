          var jsonToSend = JsonConvert.SerializeObject(json, Formatting.None);
      var multipart = new MultipartFormDataContent();
      var body = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
      multipart.Add(body, "JsonDetails");
      multipart.Add(new ByteArrayContent(System.IO.File.ReadAllBytes("E:\\file.png")), "DocumentDetails", "file1.png");
      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
      var response = httpClient.PostAsync(new Uri("uriToPost"), multipart).Result;
  
