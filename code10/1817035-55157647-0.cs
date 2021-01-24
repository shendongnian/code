     // TODO: Update with your info
        private static string apiKey = "<Your API Token>";
        private static string uploadUrl = "https://api.appcenter.ms/v0.1/apps/<Owner Name>/<App Name>/release_uploads";
        private static string releaseUrl = "https://api.appcenter.ms/v0.1/apps/<Owner Name>/<App Name>/release_uploads/";
        private static string fileToUpload = "<Path to your IPA>";
        private static string fileName = "<Your File Name>";
        
        static async Task Main(string[] args)
        {
            // Get upload url
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uploadUrl);
            requestMessage.Content = new StringContent("", Encoding.UTF8, "application/json");
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Add("X-API-Token", apiKey);
            var response = await client.SendAsync(requestMessage);
            var value = await response.Content.ReadAsAsync<UploadResponse>();
            Console.WriteLine($"Upload ID: {value.UploadId}");
            Console.WriteLine($"Upload URL: {value.UploadUrl}");
            
            // Upload file
            var uploadRequestMessage = new HttpRequestMessage(HttpMethod.Post, value.UploadUrl);
            HttpContent fileStreamContent = new StreamContent(File.OpenRead(fileToUpload));
            using (var formDataContent = new MultipartFormDataContent())
            {
                formDataContent.Add(fileStreamContent, "ipa", fileName);
                uploadRequestMessage.Content = formDataContent;
                var uploadResponse = await client.SendAsync(uploadRequestMessage);
                Console.WriteLine($"Upload Response: {uploadResponse.StatusCode}");
            }
            
            // Set to committed
            var uri = $"{releaseUrl}{value.UploadId}";
            var updateStatusMessage = new HttpRequestMessage(HttpMethod.Patch, uri);
            updateStatusMessage.Content = new StringContent("{ \"status\": \"committed\" }", Encoding.UTF8, "application/json");
            updateStatusMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            updateStatusMessage.Headers.Add("X-API-Token", apiKey);
            var updateResponse = await client.SendAsync(updateStatusMessage);
            var releaseResponse = await updateResponse.Content.ReadAsAsync<ReleaseResponse>();
            Console.WriteLine($"Release Response Id: {releaseResponse.ReleaseId}");
            Console.WriteLine($"Release Response URL: {releaseResponse.ReleaseUrl}");
