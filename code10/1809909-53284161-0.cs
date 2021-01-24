    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace SlackExample
    {
        class UploadFileExample
        {
            private static readonly HttpClient client = new HttpClient();
    
            // classes for converting JSON respones from API method into objects
            // note that only those properties are defind that are needed for this example
    
            // reponse from file methods
            class SlackFileResponse
            {
                public bool ok { get; set; }
                public String error { get; set; }
                public SlackFile file { get; set; }
            }
    
            // a slack file
            class SlackFile
            {
                public String id { get; set; }
                public String name { get; set; }
            }
    
            // sends a slack message asynchronous
            // throws exception if message can not be sent
            public static async Task UploadFileAsync(string token, string path, string channels)
            {
                // we need to send a request with multipart/form-data
                var multiForm = new MultipartFormDataContent();
                            
                // add API method parameters
                multiForm.Add(new StringContent(token), "token");
                multiForm.Add(new StringContent(channels), "channels");
    
                // add file and directly upload it
                FileStream fs = File.OpenRead(path);
                multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(path));
    
                // send request to API
                var url = "https://slack.com/api/files.upload";
                var response = await client.PostAsync(url, multiForm);
                            
                // fetch response from API
                var responseJson = await response.Content.ReadAsStringAsync();
    
                // convert JSON response to object
                SlackFileResponse fileResponse =
                    JsonConvert.DeserializeObject<SlackFileResponse>(responseJson);
    
                // throw exception if sending failed
                if (fileResponse.ok == false)
                {
                    throw new Exception(
                        "failed to upload message: " + fileResponse.error
                    );
                }
                else
                {
                    Console.WriteLine(
                            "Uploaded new file with id: " + fileResponse.file.id
                    );
                }
            }
    
            static void Main(string[] args)
            {
                // upload this file and wait for completion
                UploadFileAsync(
                    "xoxp-YOUR-TOKEN",
                    "C:\\temp\\Stratios_down.jpg",
                    "test"
                ).Wait();
                
                Console.ReadKey();
    
            }
        }
    
    }
