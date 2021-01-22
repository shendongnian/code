    public struct Distance
    {
         private Distance(int inches)
         {
             this.totalInches = inches;
         }
         private int totalInches;
         public int Inches { get { return this.totalInches % 12; }  }
         public int Feet { get { return this.totalInches / 12; } }
 
         public static Distance FromInches(int inches)
         {
              return new Distance(inches);
         }
         public static Distance FromFeet(int feet)
         {
              return new Distance(feet * 12);
         }
         public static Distance FromFeetAndInches(int feet, int inches)
         {
              return new Distance(feet * 12 + inches);
         }
    }
