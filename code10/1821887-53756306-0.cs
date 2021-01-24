    { "FileVersion":"11.03", "ChargesDetail":{ "DiscountRate":0.0, "DiscountAmount":0.0 } } 
    public class ChargesDetail
    {
       public double DiscountRate { get; set; }
       public Amount DiscountAmount { get; set; }
    }
    
    public class Amount:IConvertible 
    { 
       
    }
