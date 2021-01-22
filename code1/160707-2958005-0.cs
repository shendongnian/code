    public class OuterClass
    {
        //OuterClass methods
        public class InnerClass
        {
            private OuterClass _outer;
            public InnerClass(OuterClass outer)
            {
                _outer = outer;
            }
        }
    }
 
