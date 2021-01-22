    using System;
    using System.IO;
    using System.Net.Http;
    namespace HttpClientTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var client = new HttpClient();
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(File.Open("../../Image1.png", FileMode.Open)), "Image", "Image.png");
                var result = client.PostAsync("https://hostname/api/Account/UploadAvatar", content);
                Console.WriteLine(result.Result.ToString());
            }
        }
    }
