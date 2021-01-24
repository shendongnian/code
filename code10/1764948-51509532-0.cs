    class demo
    {
        public string firstValue { get; set; }
        public string secondValue { get; set; }
    }
    string json = "{\"Date\": \"01/01/2019\", \"0\": \"John\", \"1\": \"Jack\", \"3\": \"Tom\", \"4\": \"Will\", \"5\": \"Joe\"}";
    var obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(json);
    List<demo> children = obj.Children().Select(c => new demo()
    {
        firstValue = ((Newtonsoft.Json.Linq.JProperty)c).Name,
        secondValue = ((Newtonsoft.Json.Linq.JProperty)c).Value.ToString()
    }).ToList();  
