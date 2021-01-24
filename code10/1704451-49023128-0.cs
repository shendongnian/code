    public class LabelResult
    {
        public long order_id { get; set; }
        public string order_number { get; set; }
        public string carrier_name { get; set; }
        public List<string> tracking_numbers { get; set; }
        public List<byte []> labels { get; set; }
        public List<string> label_types { get; set; }
        public bool success { get; set; }
    }
