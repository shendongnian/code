    class Example
    {
        public Example(int value1)
            : this(value1, "Default Value")
        {
        }
        public Example(int value1, string value2)
        {
            m_Value1 = value1;
            m_value2 = value2;
        }
        int m_Value1;
        string m_value2;
    }
