    Interface IClubManager 
    {
      public void RegisterMember();        
    }
    
    Interface ICoach 
    {
       // code for making a team formation.. 
    }
    class SomeDesignation : ICoach, IClubManager 
    {
    }
