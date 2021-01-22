    namespace My.Namespace
    {
        public class MyClassA
        {
            public void MyMethod()
            {
                // Use value from MyOtherClass
                int myValue = My.Other.Namespace.MyOtherClass.MyInt;
            }
        }
    }
    
    namespace My.Other.Namespace
    {
        public class MyOtherClass
        {
            private static int myInt;
            public static int MyInt
            {
                get {return myInt;}
                set {myInt = value;}
            }
            // Can also do this in C#3.0
            public static int MyOtherInt {get;set;}
        }
    }
