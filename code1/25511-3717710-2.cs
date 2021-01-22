    namespace  A { 
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
    
