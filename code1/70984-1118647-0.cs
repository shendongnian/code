    namespace Company.General.Project1
    {
       public static class Rainbow
       {
        [Flags]
        public enum Colours
        {
          Red,
          Blue,
          Orange
        }
      }
    }
    
    using Company.General.Project1;
    
    namespace Company.SpecialProject.Processing
    {
      public class MixingPallette
      {
        int myValue = (int)Colours.Red;
      }
    }
