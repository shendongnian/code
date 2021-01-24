    public class Ping
    {
        public long Id { get; set; }
        public long IdDevice { get; set; }
        public virtual Device Device { get; set; }//Newly added
        public string Request { get; set; }
        public string Response { get; set; }
        public int RspCode { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
