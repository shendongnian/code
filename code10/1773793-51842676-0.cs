    public class UpdateResultSt
    {
        public bool isSuccess { get; set; }
        public int elapsed { get; set; }
    
        public Dictionary<string,string> results { get; set; }
        public Dictionary<string,string> errors { get; set; }
    }
