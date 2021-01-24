    using HTTPClient
    
    
    string baseUrl = "https://vspark-demo.vocitec.com/transcribe/M2ComSys-Pilot/eng1CCStereo/";
    
               
    
                HttpClient client = new HttpClient();
               
                MultipartFormDataContent form = new MultipartFormDataContent();
                HttpContent content = new StringContent("file");
                HttpContent DictionaryItems = new FormUrlEncodedContent(new[] {
           new KeyValuePair<string, string>("token", "ee22c61a55bd0629c8c8a63a8c8b73ed"),
       });
                form.Add(content, "files");
                // form.Add(DictionaryItems, "data");
                form.Add(new StringContent("ee22c61a55bd0629c8c8a63a8c8b73ed"), "token");
                 var stream = new FileStream(@"D:\audio\variety.wav", FileMode.Open);
                content = new StreamContent(stream);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = "variety.wav"
                };
                form.Add(content);
    
                HttpResponseMessage response = null;
    
                try
                {
                    response = (client.PostAsync(baseUrl, form)).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(response);
                var k = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(k);
                Console.ReadLine();
            }
