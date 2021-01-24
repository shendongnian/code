    public class ChargesDetail
    {
       public double DiscountRate { get; set; }
       public Amount DiscountAmount { get; set; }
    }
    
    public class Amount:IConvertible 
    { 
       public double DiscountAmountVar{get;set;}
    }
