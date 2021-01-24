    public class AWSRoot
    {
        public string APNS { get; set; }
        public AWSRoot(string payload) 
        {
            APNS = payload;
        }
    }
