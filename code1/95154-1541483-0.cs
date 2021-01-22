    public class BaseFieldValue<T>
    {
        public struct Special
        {
            internal string m_value;
            public Special(string value)
            {
                m_value = value;
            }
        }
        public BaseFieldValue()
        {
            //...
        }
    
        public BaseFieldValue(Special value)
        {
            //...
        }
    
        public BaseFieldValue(T value)
        {
            //...
        }
    }
