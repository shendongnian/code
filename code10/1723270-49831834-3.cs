    public class FaceApiHttpClient {
        private readonly HttpClient client;
        public FaceApiHttpClient(HttpClient client) {
            this.client = client;
        }
        public async Task<string> GetStringAsync(byte[] byteData, string uri) {            
            using (var content = new ByteArrayContent(byteData)) {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                // Execute the REST API call.
                HttpResponseMessage response;  response = await _client.PostAsync(uri, content).ConfigureAwait(false);
                // Get the JSON response.
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
    
