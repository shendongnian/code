    public class ProviderOperator
    {
        public List<Provider> providers { get; set; }
    }
    public class Provider
    {
        public int provider_id { get; set; }
        public string provider_name { get; set; }
        public string provider_code { get; set; }
        public int service_id { get; set; }
        public string service { get; set; }
        public string provider_image { get; set; }
        public string status { get; set; }
    }
    var ob = JsonConvert.DeserializeObject<ProviderOperator>(json);
