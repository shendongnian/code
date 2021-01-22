    public class A
    {
        private static class Wrapped
        {
            private static void A()
            {
                secred code
            }
 
            public static void B()
            {
                A();
            }
        }
        public void UsingA()
        {
            Wrapped.B();
        }
    }
