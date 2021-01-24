    public class JsonModel
    {
        public List<Detail> details { get; set; }
    }
    public class Detail
    {
        public string id { get; set; }
        public string tran_id { get; set; }
        public string tran_type { get; set; }
        public string tran_status { get; set; }
        public string expiry_date_time { get; set; }
        public string number { get; set; }
    }
   
