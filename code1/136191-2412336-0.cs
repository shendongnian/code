    public class SomeAmount : IAmount
    {
      decimal amount;
      public decimal Amount 
      { 
           get{return this.amount;}
           set{this.amount=value; }
      }
    }
