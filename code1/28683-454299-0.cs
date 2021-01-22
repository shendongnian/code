    public class MyCleverEnum
    {
        public static readonly MyCleverEnum First = new FirstCleverEnum();
        public static readonly MyCleverEnum Second = new SecondCleverEnum();
        // Can only be called by this type *and nested types*
        private MyCleverEnum()
        {
        }
        public abstract void SomeMethod();
        public abstract void AnotherMethod();
 
        private class FirstCleverEnum : MyCleverEnum
        {
            public override void SomeMethod()
            {
                 // First-specific behaviour here
            }
            public override void AnotherMethod()
            {
                 // First-specific behaviour here
            }
        }
        private class SecondCleverEnum : MyCleverEnum
        {
            public override void SomeMethod()
            {
                 // Second-specific behaviour here
            }
            public override void AnotherMethod()
            {
                 // Second-specific behaviour here
            }
        }
    }
