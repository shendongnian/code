    public class AnimalFeetFacade
    {
      public AnimalFeetFacade(AnimalType theType)
      {
        if (theType == AnimalType.Pig)
        {
          _washFeet = WashPigFeet;
          //TODO reference more PigFeet methods here
        }
        else if (theType == AnimalType.Horse)
        {
           _washFeet = WashHorseFeet;
           //TODO reference more HorseFeet methods here
        }
        else
        {
           throw new NotImplementedException("AnimalFeetFacade only works with PigFeet and HorseFeet");
        }
      }
    
      protected Action _washFeet;
    
      public void WashFeet()
      {
        _washFeet.Invoke();
      }
    
      protected void WashPigFeet()
      {
        PigFeet.Feet = new PigFeet.Feet()
        feet.WashFeet()
      } 
    
      protected void WashHorseFeet()
      {
        HorseFeet.Feet = new HorseFeet.Feet()
        feet.WashFeet()
      }
    }
