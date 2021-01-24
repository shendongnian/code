    public abstract class Outer
    {
         public static Outer GetOuter(...)
         {
             if (someConditionMet) return new InnerSpecialized1();
             return new InnerSpecialized2();
         } 
         private Outer() { ... } //avoids anyone form extending Outer
         private class InnerSpecialized1: Outer { ... }
         private class InnerSpecialized2: Outer { ... }
    }
