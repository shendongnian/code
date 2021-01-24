    public class ReverseGeocodeResult
    {
        public PlusCode plus_code { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
    public class PlusCode
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }
