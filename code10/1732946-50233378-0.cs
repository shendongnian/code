    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        public int lat { get; set; }
        public int lon { get; set; }
        public DateTime date_iso { get; set; }
        public int date { get; set; }
        public float value { get; set; }
    }
    string json  = @"[{""lat"":54,""lon"":9,""date_iso"":""2018 - 05 - 08T12: 00:00Z"",""date"":1525780800,""value"":5.62}]";
    Class1[] result = JsonConvert.DeserializeObject<Class1[]>(json);
