    public class FilterPageModel  {
        public int skip { get; set; }
        public int page { get; set; }
        public Filter filter{ get; set; }
    }   
    
    public class Filter
    {         
        public string logic{ get; set; }
        public List<FieldFilter> filters{ get; set; }
    }
    
    public class FieldFilter
    {         
        public string field{ get; set; }
        public string operator{ get; set; }
        public string value{ get; set; }
    }
