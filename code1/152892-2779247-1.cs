    class Base
    {
       public static void F() {}
    }
    class Derived: Base
    {
       new private static void F() {}   // Hides Base.F in Derived only
    }
    class MoreDerived: Derived
    {
       static void G() { F(); }         // Invokes Base.F
    }
