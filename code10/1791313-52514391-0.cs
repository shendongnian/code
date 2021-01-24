    var cloudVisionUrl = $"{annotationTextApiUrl}{annotationTextApiKey}";
    
                var imageBase64 = DoYourOwnImageToBase64(path);
    
                var client = new HttpClient();
    
                var requests = new ApiRequest { Requests = new List<Request> { new Request { Image = new Image {Content = imageBase64}, Features = new List<Feature> {new Feature {Type = "TEXT_DETECTION"}} } } };
    
                var httpResponse = await client.PostAsJsonAsync(cloudVisionUrl, requests);
// -----------------------------------------
    public class ApiRequest
        {
            public ApiRequest()
            {
                Requests = new List<Request>();
            }
    
            [JsonProperty("requests")]
            public List<Request> Requests { get; set; }
        }
    public class Request
        {
            [JsonProperty("image")]
            public Image Image { get; set; }
    
            [JsonProperty("features")]
            public List<Feature> Features { get; set; }
        }
    public class Feature
        {
            [JsonProperty("type")]
            public string Type { get; set; }
        }
