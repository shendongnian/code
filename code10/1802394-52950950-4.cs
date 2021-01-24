    public class SomeVM
    {
       public int CustId { get; set; }    
       public List<FuelQuantity> FuelQuantities { get; set; }
       public int Total { get; set; }
       SomeVM()
       {
          FuelQuantities = new List<FuelQuantity>();
       }
 
    }
