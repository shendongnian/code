    public class SystemJSON
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ResponseData ResponseData { get; set; }
    }
    
    public class ResponseData {
    	public Department dept {get; set; }
    }
    
    public class Department {
    	public string id {get; set; }
    	public string description {get; set; }
    	public int status {get; set; }
    }
