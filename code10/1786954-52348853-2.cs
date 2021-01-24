    void Main()
    {
        var client = new HttpClient();
        HttpResponseMessage response = client.GetAsync("url").GetAwaiter().GetResult();
        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    
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
