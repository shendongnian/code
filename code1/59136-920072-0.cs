    class Meh 
    {
      private Meh() { }
      private static Meh theMeh = new Meh();
      public static Meh getInstance() { return theMeh; }
    }
