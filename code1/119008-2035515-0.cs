    using System;
    namespace CSharp
    {
        public class MyClass
        {
            public static string Overload1<a, b>(a x, b y) { return "Pim"; }
            public static string Overload1<a, b>(Tuple<a, b> x) { return "Pam"; }
            public static string Overload1<a>(a x) { return "Pum"; }
        }
    }
