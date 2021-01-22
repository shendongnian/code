    public interface ICursor
    {
    
    }
    
    public class TextGrid
    {
      private class Cursor : ICursor
      {
      }
    
      // This could be a property if it doesn't require much calculation.
      public ICursor GetCursor()
      { 
      }
    }
