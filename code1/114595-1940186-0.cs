    public class Meter
    {
       private int _powerRating = 0; 
       private Production _production;
    
       public Meter()
       {
          _production = new Production(this);
       }
    }
