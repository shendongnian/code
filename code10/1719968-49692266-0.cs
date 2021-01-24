    public class RootObject
    {
        public List<List<List<double>>> coordinates { get; set; }
    }
    string adjustedFragment = "{ " + json + " }";
    RootObject r = JsonConvert.DeserializeObject<RootObject>(adjustedFragment);
