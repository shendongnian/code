       class Source
   {
      public Source() { }
      public Source(int x, int y, int z)
      {
         myX = x;
         myY = y;
         myZ = z;
      }
      private int myX;
      public int X
      {
         get { return myX; }
         set { myX = value; }
      }
      private int myY;
      public int Y
      {
         get { return myY; }
         set { myY = value; }
      }
      private int myZ;
      public int Z
      {
         get { return myZ; }
         set { myZ = value; }
      }
