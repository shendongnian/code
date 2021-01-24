    void Main()
    {
        string json = "{\"ANDE\":     {\"chart\":[     {\"date\":\"20180914\",\"minute\":\"09:30\"},{\"date\":\"20180914\",\"minute\":\"13:30\"}]},\"DAR\":     {\"chart\":[     {\"date\":\"20180914\",\"minute\":\"09:30\"},{\"date\":\"20180914\",\"minute\":\"13:30\"}]}}";
        var result = JsonConvert.DeserializeObject<Dictionary<string, DateResponse>>(json)
        .Select(i => i.Value)
        .SelectMany(i => i.Chart);
    }
    
    public class DateResponse{
        public List<HistoricalDataResponse> Chart { get; set; }
    }
    
    public class HistoricalDataResponse
    {
        public string date { get; set; }
        public string minute { get; set; }
    }
