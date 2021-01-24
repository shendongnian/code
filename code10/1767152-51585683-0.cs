    This is your base class
    public class Fruit{
         public double Price { get; set; }
         public string Origins { get; set; }
    
         //or you can create a constructor
         //one default constructor
         public virtual void GetPrice()
         {
              Price = 69;
         }
    }
