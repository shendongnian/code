    HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://export.highcharts.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("", content).Result;
            if (response.IsSuccessStatusCode)
            {
                FileStream fileStream = new FileStream(pathname, FileMode.Create, FileAccess.Write, FileShare.None);
                response.Content.CopyToAsync(fileStream).ContinueWith(
                   (copyTask) =>
                   {
                       fileStream.Close();
                   });
            }
            else
            {
                Console.WriteLine($"Failed to poste data. Status code:{response.StatusCode}");
            }
