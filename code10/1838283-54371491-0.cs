    // Class names should be words, not abbrvtns like "Pos"
    public class Position
    {
      private int x;
      private bool IsValidX(int possibleX)
      {
        // Here return true if possibleX is valid, false otherwise
      }
      public int X 
      { 
        get { return this.x; } 
        set 
        {
          if (!IsValidX(value))
            throw new ArgumentException("explanation here", "value");
          this.x = value;
        }
      }
      // Now do the same thing for Y.
      public Position(int x, int y)
      {
        if (!IsValidX(x)) 
          throw new ArgumentException("explanation here", "x");
        if (!IsValidY(y))
          throw new ArgumentException("explanation here", "y");
        this.x = x;
        this.y = y;
      }
    }
