    public static class Extensions
    {
      public static MyClass MakeStatusTheSame(this MyClass mc, MySecondClass msc)
      {
        mc.status = msc.status
        return mc; /* make the method chainable */
       }
    }
