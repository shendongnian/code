            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3978/");
               
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                MultipartFormDataContent content = new MultipartFormDataContent();
                string filepath = "C:/Users/user/Desktop/TestFiles/testing.xml";
                string filename = "test.xml";
                ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filepath));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = filename };
                content.Add(fileContent);
                HttpResponseMessage response = await client.PostAsync("api/response?firstname=bob&lastname=smith", content);
                string returnString = await response.Content.ReadAsStringAsync();
                Console.Write(returnString);
            }
