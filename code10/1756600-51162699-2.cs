     public static async Task get()
        {
                HttpClient _httpClient = new HttpClient())
                string url = "https://someurl.com";
                var result = await _httpClient.GetAsync($"{url}");
                // contents to a log file
                string resultContent = await result.Content.ReadAsStringAsync();
                File.WriteAllText("D://dT.pdf", resultContent);
                // ... write to log
        }
