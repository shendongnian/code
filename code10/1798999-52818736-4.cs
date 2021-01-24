    public class Response
    {
          public Geography Geography {get; set;}
    }
    public class Geography
    {
           public Vendor Vendor{get;set;}
    }
    public class Vendor
    {
          public List<Region> Regions {get;set;}
    }
    public class Region
    {
    }
    
