        public class A : ISomeInterface
        {
            public static readonly A Instance = new A();
            private A()
            {
            }
        }
        public class B : ISomeInterface
        {
            public static readonly B Instance = new A();
            private B()
            {
            }
        }
