     public class list_TA
    {
        public DateTime SAMPLE_TIME { get; set; }
        public string WAIT_CLASS { get; set; }
        public double COUNT { get; set; }
        public list_TA()
        {
                
        }
        public list_TA(DateTime SAMPLE_TIME, string WAIT_CLASS, double COUNT) 
        {
            this.SAMPLE_TIME = SAMPLE_TIME;
            this.WAIT_CLASS = WAIT_CLASS;
            this.COUNT = COUNT;
        }
    }
