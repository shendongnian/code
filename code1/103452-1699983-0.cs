    public class ValueHolder
    {
        private static ValueHolder m_singleton = null;
        private int m_someValue;
    
        private ValueHolder()
        {
            m_someValue = 0;
        }
    
        public static ValueHolder Instance
        {
            get
            {
                if (m_singleton = null)
                    m_singleton = new ValueHolder();
                return m_singleton;
            }
        }
    
        public int SomeValue
        {
            get { return m_someValue; }
            set { m_someValue = value; }
        }
    }
