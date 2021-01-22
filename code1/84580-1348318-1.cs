    public class MyClass : Observable
    {
        private bool m_someProperty;
        
        public bool SomeProperty
        {
            get { return m_someProperty; }
            set { SetProperty(ref m_someProperty, value, "SomeProperty"); }
        }
    }
