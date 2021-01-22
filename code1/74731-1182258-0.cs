    public class Base {
        protected BindingList<SampleBase> m_samples;
        public Base() { }
        public BreakDerived() { m_samples.Add(new SampleDerived2()); }    
    }
    public class Derived : Base {
        public Derived() { m_samples = new BindingList<SampledDerived>(); }
    }
