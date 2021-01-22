    class HardwareElement
    {
        public HardwareElement(string topic, DateTime date)
        {
           this.Topic = topic;
           this.Date = date;
        }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
    }
