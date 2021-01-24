    public class MyClass
    {
        private Dictionary<string, string> myDictionary;
        private readonly HttpClient httpClient;
        public MyClass(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task StartAsync()
        {
            myDictionary = await UploadAsync("some file path");
        }
        public async Task<Dictionary<string, string>> UploadAsync(string filePath)
        {
            byte[] fileContents;
            using (FileStream stream = File.Open(filePath, FileMode.Open))
            {
                fileContents = new byte[stream.Length];
                await stream.ReadAsync(fileContents, 0, (int)stream.Length);
            }
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            // your request stuff here
            HttpResponseMessage httpResponse = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
            // parse response and return the dictionary
        }
    }
