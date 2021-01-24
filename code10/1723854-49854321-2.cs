    public struct Point {
      public Point(int x, int y) {
        X = x;
        Y = y;    
      }
      //DONE: Exposing fields is a bad practice; converted to property
      //DONE: struct are often immutable (private set) 
      public int X {get; private set;}
      public int Y {get; private set;}
    }
