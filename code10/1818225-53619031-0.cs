    internal class BaseOuter
    {
        protected BaseInner baseInner;
        protected internal BaseOuter(BaseInner inner = null)
        {
            Console.WriteLine("BaseOuter Constructor");
            /*  lots of stuff I want in derived class */
        }
        protected internal class BaseInner
        {
            public int x;
            public BaseInner()
            {
                /* stuff that is needed in DerivedInner too */
                Console.WriteLine("        BaseInner Constructor");
                x = 2;
            }
        }
    }
    internal class DerivedOuter : BaseOuter
    {
        protected internal DerivedOuter()
         :base(new DerivedInner())
        {
            Console.WriteLine("DerivedOuter Constructor (finished)");
        }
        protected internal class DerivedInner : BaseInner
        {
            public double y;
            public DerivedInner()
            {
                Console.WriteLine("        DerivedInner Constructor");
                y = 2d;
            }
        }
    }
