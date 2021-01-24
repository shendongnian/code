    var properties = new prop();
    var json = JsonConvert.SeralizeObject(properties);
    
    public class prop 
    {
         public string account_id { get; set;}
         public string name { get; set;}
         public int age { get; set;}
    
    }
