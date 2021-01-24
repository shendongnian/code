    public class Rootobject
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public Coverageoption[] coverageOptions { get; set; }
        public object[] errorMessages { get; set; }
        public bool success { get; set; }
    }
    public class Coverageoption
    {
        public float premiumAnnual { get; set; }
    }
    string yourJsonString= "{"data":{"coverageOptions":[{"premiumAnnual":11257.9284 }],"errorMessages":[],"success":true}}";
    var result = JsonConvert.DeserializeObject<Rootobject>(yourJsonString);
