    public class PageDetail
    {
        public string areaName { get; set; }
        public string coordiante { get; set; }
        public string coordinate { get; set; }
    }
    
    public class PageNumber
    {
        public List<PageDetail> Page_Details { get; set; }
    }
    
    public class Template
    {
        public string Template_Name { get; set; }
        public List<PageNumber> Page_Number { get; set; }
    }
