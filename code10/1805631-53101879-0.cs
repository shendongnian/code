    public static class Enums
    {
      [Flags]
      public enum Roles
      {
        uknown = 0,
        Admin= 1 << 1,
        Guest = 1 << 2
      }
    }
