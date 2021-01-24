    class A: Base
    {
         public static A GetA(string instanceName) =>
             GetBase(instanceName) as A;
         //...
    }
    class B: Base
    {
         public static B GetB(string instanceName) =>
             GetBase(instanceName) as B;
         //...
    }
