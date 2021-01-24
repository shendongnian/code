    public class Response
    {
        [JsonProperty("companies")
        public Company[] Companies { get; set; }
    }
    
    var companiesResponse = JsonConvert.DeserializeObject<Response>(companyResponse.Content);
