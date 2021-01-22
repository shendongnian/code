    public enum ArrowDirection
    {
        North,
        South,
        East,
        West
    }
    
    public static class ArrowDirectionExtensions
    {
         public static UnitVector UnitVector(this ArrowDirection self)
         {
             // Replace this with a dictionary or whatever you want ... you get the idea
             if(self == ArrorDirection.North)
             {
                  return new UnitVector(1,1);
             }
    
             if(self == ArrowDirection.South)
             {
                  return new UnitVector(1,1);
             }
    
             // Etc.
         }
    }
