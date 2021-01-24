    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    
    namespace SlackApp
    {
        public class PostFile
        {
            string path = @"C:\Users\Stratios_down.jpg";
    
            public byte[] ReadImageFile()
            {
                FileInfo fileInfo = new FileInfo(path);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);
                byte[] imageData = br.ReadBytes((int)imageFileLength);
                return imageData;
            }
        }
    
        public class SlackClient
        {
            private readonly Uri _webhookUrl;
            private readonly HttpClient _httpClient = new HttpClient { };
    
            public SlackClient(Uri webhookUrl)
            {
                _webhookUrl = webhookUrl;
            }
    
            public async Task<HttpResponseMessage> UploadFile(byte[] file)
            {
                var requestContent = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(file);            
                requestContent.Add(fileContent, "file", "stratios.jpg");
    
                var response = await _httpClient.PostAsync(_webhookUrl, requestContent);
                return response;
            }
        }
    
        class TestArea
        {
            public static void Main(string[] args)
            {
                Task.WaitAll(IntegrateWithSlackAsync());
            }
    
            private static async Task IntegrateWithSlackAsync()
            {
                var webhookUrl = new Uri(
                    "https://slack.com/api/files.upload?token=xoxp-MY-TOKEN&channels=test"
                );
                var slackClient = new SlackClient(webhookUrl);
                
                PostFile PF = new PostFile();
                var testFile = PF.ReadImageFile();
        
                var response = await slackClient.UploadFile(testFile);
    
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                Console.ReadKey();
                
            }
        }
    }
