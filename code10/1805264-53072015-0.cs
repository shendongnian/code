    public class Data
    {
        public Content1 content1 { get; set; }
    
        public Content2 content2 { get; set; }
    
        public string name { get; set; }
    
        public string address { get; set; }
    
        public string age { get; set; }
    }
    var object1 = JsonConvert.DeserializeObject<Data>(message1);
