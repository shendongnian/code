    public class RequestModel
    {
        public string job_id { get; set; }
        public Consignment consignment { get; set; }
        public RequestModel()
        {
            consignment = new Consignment();
        }                
        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
