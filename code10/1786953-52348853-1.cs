    void Main()
    {
        string json = "{\"ANDE\":     {\"chart\":[     {\"date\":\"20180914\",\"minute\":\"09:30\"},{\"date\":\"20180914\",\"minute\":\"13:30\"}]},\"DAR\":     {\"chart\":[     {\"date\":\"20180914\",\"minute\":\"09:30\"},{\"date\":\"20180914\",\"minute\":\"13:30\"}]}}";
        //var result = response.Content.ReadAsAsync<Dictionary<string, DateResponse>>().GetAwaiter().GetResult();
        var result = JsonConvert.DeserializeObject<Dictionary<string, DateResponse>>(json);
        
        foreach (var element in result)
        {
            var key = element.Key; // ANDE
            foreach (var item in element.Value.Chart)
            {
                var date = item.date;
                var minute = item.minute;
            }
        }
    }
    
    public class DateResponse{
        public List<HistoricalDataResponse> Chart { get; set; }
    }
    
    public class HistoricalDataResponse
    {
        public string date { get; set; }
        public string minute { get; set; }
    }
