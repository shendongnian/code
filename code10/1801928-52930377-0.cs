    public abstract class Form
    {
        public string SentByName { get; set; }
        public string SentByEmail { get; set; }
        public DateTime ReceivedByDateTime { get; set; }
        public Form()
        {
            this.SentByEmail = "ds@ds.com";
            this.SentByName = "DS";
            this.ReceivedByDateTime = DateTime.Now
        }
    }
