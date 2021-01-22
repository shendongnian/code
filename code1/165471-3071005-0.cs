        public class A<T> where T : class
        {
            public virtual A<T> ARef
            {
                get { return default(A<T>); }
            }
        }
    
        public class B : A<B>
        {
            public override A<B> ARef
            {
                get
                {
                    return base.ARef;
                }
            }
        }
