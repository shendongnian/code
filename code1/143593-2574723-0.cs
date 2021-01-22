    interface IPrices_As_String{
     string OD { get; set; }
     // other properties here...
    }
    
    interface IPrices{
     decimal Today{get; set;}
    }
    
    class Prices : IPrices, IPrices_As_String{
     public decimal Today { get; set; }
     public string IPrices_As_String.OD {
      get { return this.Today.ToString(); }
      set { if(!String.IsNullOrEmpty(value)){
       this.Today = decimal.Parse(value);
      }}
     }
    }
