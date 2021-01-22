    public class Base
    {
        protected BindingList<SampleBase> m_samples = new BindingList<Derived>();
    
        public Base() { }
    }
    public class Derived : Base
    {
        public FwdRunData()
        {
            m_samples.Add(new Derived>());
        }
    }
