    public class Banana : Fruit{
         public string peelDensity { get; set; }    
          //this is a sample of Default Constructor
         public Banana()
                :base()
         {
              Price = 0; //here you're setting default value to banana once it's initialized
         }
         public override void GetPrice()
        {
              //base.GetPrice(); //here you get the value from the Parent Class 
                Price = 100; // here you're setting a value for the price of Banana once you call this method;
        }
    }
