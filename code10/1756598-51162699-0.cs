        public static async Task get()
        {
            using (HttpClient _httpClient = new HttpClient()) { 
             string url = "https://someurl.com";
                var result = await _httpClient.GetAsync($"{url}");
                    // Do something with the contents, like write the statuscode and
                    // contents to a log file
                    string resultContent = await result.Content.ReadAsStringAsync();
                    File.WriteAllText("D://dT.pdf", resultContent);
                // ... write to log
                
            }
        }
