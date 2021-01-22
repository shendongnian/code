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
             switch(self)
             {
                 case ArrowDirection.North:
                     return new UnitVector(0, 1);
                 case ArrowDirection.South:
                     return new UnitVector(0, -1);
                 case ArrowDirection.East:
                     return new UnitVector(1, 0);
                 case ArrowDirection.West:
                     return new UnitVector(-1, 0);
                 default:
                     return null;
             }
         }
    }
