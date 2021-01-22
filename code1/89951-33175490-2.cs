    public class ClassA
    {
        // public
        public virtual int MyProperty { get; set; }
        // protected
        protected virtual int MyProperty2 { get; set; }
    }
    public class ClassB
    {
        protected ClassC MyClassC;
        public ClassB()
        {
            MyClassC = new ClassC();
        }
        protected int MyProperty2
        {
            get { return MyClassC.MyProperty2; }
            set { MyClassC.MyProperty2 = value; }
        }
        protected int MyProperty
        {
            get { return MyClassC.MyProperty; }
            set { MyClassC.MyProperty = value; }
        }
        protected class ClassC : ClassA
        {
            public new int MyProperty2
            {
                get { return base.MyProperty2; }
                set { base.MyProperty2 = value; }
            }
            public override int MyProperty
            {
                get { return base.MyProperty; }
                set { base.MyProperty = value; }
            }
        }
    }
