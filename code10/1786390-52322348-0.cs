    static async void WR(int msg)
    {
        Console.WriteLine(msg + " begin");
        string url = "https://stackoverflow.com";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>
                (request.BeginGetResponse, request.EndGetResponse, null);
        Console.WriteLine(msg + " status code: " + response.StatusCode);
        Console.WriteLine(msg + " end");
        response.Dispose();
    }
