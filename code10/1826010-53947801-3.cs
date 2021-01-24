    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://tfsServer:8080/tfs/DefaultCollection/TeamProject/_apis/build/builds?api-version=4.0");
    request.Credentials = CredentialCache.DefaultNetworkCredentials;
    request.Method = "Post";
    request.ContentType = "application/json";
    Stream stream = request.GetRequestStream();
    string json = "{\"definition\":{\"id\":63}}";
    byte[] buffer = Encoding.UTF8.GetBytes(json);
    stream.Write(buffer, 0, buffer.Length);
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Console.Write(response.StatusCode);
    using (var streamReader = new StreamReader(response.GetResponseStream()))
    {
         var result = streamReader.ReadToEnd();
    }
    Console.Read();
