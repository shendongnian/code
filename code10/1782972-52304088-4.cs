    private static async Task Main(string[] args) // async main available in c# 7.1 
    {
        Console.WriteLine($"Test starts at {DateTime.Now.ToString("o")}");
        FileStream fileStream = new FileStream(@"C:\Windows10Upgrade\Windows10UpgraderApp.exe", FileMode.Open);
        MyFile vFile = new MyFile()
        {
            Lenght = 0,
            Path = "https://c2calrsbackup.blob.core.windows.net/containername/Windows10UpgraderApp.exe",
            RelativePath = "Windows10UpgraderApp.exe"
        };
        await UploadStream(vFile, fileStream);
        Console.WriteLine($"Test ends at {DateTime.Now.ToString("o")}");
        Console.Write("Press any key to exit...");
        Console.ReadKey();
    }
    private static async Task UploadStream(MyFile myFile, Stream stream)
    {
        try
        {
            using (HttpClient httpClient = new HttpClient()) // instance should be shared
            {
                httpClient.BaseAddress = new Uri("https://localhost:5000");
                using (MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent())
                {
                    multipartFormDataContent.Add(new StringContent(JsonConvert.SerializeObject(myFile), Encoding.UTF8, "application/json"), nameof(MyFile));
                    // Here we add the file to the multipart content.
                    // The tird parameter is required to match the `IsFileDisposition()` but could be anything
                    multipartFormDataContent.Add(new StreamContent(stream), "stream", "myfile");
                    HttpResponseMessage httpResult = await httpClient.PostAsync("api/uploaddownload/upload", multipartFormDataContent).ConfigureAwait(false);
                    httpResult.EnsureSuccessStatusCode();
                    // We don't need any result stream anymore
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
