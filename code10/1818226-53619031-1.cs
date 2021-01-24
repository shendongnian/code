    internal class BaseOuter
    {
        protected BaseInner baseInner;
        protected internal BaseOuter(BaseInner inner = null)
        {
            baseInner = inner ?? new BaseInner();
            Console.WriteLine("BaseOuter Constructor");
            /*  lots of stuff I want in derived class */
            // This is an anti-pattern I want to avoid
            //https://www.jetbrains.com/help/resharper/2018.2/VirtualMemberCallInConstructor.html
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
