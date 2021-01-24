    Uri baseURI = new Uri("https://jsonplaceholder.typicode.com/posts/1");
    string apiPath = "";
    using (var client = new HttpClient(new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) =>
        {
            Console.WriteLine(certificate2.GetNameInfo(X509NameType.SimpleName, false));
            return true;
        }
    }))
    {
        client.BaseAddress = baseURI;
        HttpResponseMessage response = await client.GetAsync(apiPath);
        Console.WriteLine("HTTP status code: " + response.StatusCode.ToString());
    }
