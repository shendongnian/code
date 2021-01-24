    string uri = "http://localhost:2000/BookInfo";
    WebClient client = new WebClient();
    client.Headers["Content-type"] = "application/json";
    client.Encoding = Encoding.UTF8;
    string s = "{\"bookInfo\":{\"Name\":\"ab\"}}";
    string result = client.UploadString(uri, "POST", s);
    Console.WriteLine(result);
