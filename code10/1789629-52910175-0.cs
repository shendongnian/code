    static int Main(string[] args)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("http://localhost:10442/filetest")
        };
        var path = "c:\\temp\\foo.bak";
        using (var filestream = File.OpenRead(path))
        {
            var length = filestream.Length.ToString();
            var streamContent = new StreamContent(filestream);
            streamContent.Headers.Add("Content-Type", "application/octet-stream");
            streamContent.Headers.Add("Content-Length", length);
            request.Content = streamContent;
            Console.WriteLine($"Sending {length} bytes");
            var response = new HttpClient().SendAsync(request).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
        Console.WriteLine("Hit any key to exit");
        Console.ReadKey();
        return 0;
    }
