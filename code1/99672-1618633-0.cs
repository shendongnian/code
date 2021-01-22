    public class ClassBase
    {
        public int MyProperty
        {
            get;
            protected set;
        }
    }
    public sealed class ClassDerived : ClassBase
    {
        public ClassDerived()
        {
            MyProperty = 4; // will set
        }
    }
    public class ClassUsingDerived
    {
        public ClassUsingDerived()
        {
            ClassDerived drv = new ClassDerived();
            drv.MyProperty = 5; // will fail
        }
    }
