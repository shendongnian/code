        public class MyClass { }
    }
    namespace namespaceB
    {
        public class A
        {
            public class MyClass { }
        }
        public class OtherClass
        {
            public A.MyClass MyAClass;
        }
    }
    
     Explanation
      In the example above, the compiler would always resolve the MyAClass to the type namespaceB.A.MyClass. If you wanted it to be A.MyClass, there was no way to do it until C# 2.0.  In C# 2.0, you would use: public class MyOtherClass  { public global::A.MyClass yAClass; } To indicate that you shouldn't use the local namespace scope, but rather, the root namespace.
