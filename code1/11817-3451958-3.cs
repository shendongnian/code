    public class Base
    {
        private int m_basePrivateField = 0;
        public class Derived : Base
        {
            public int BrokenAccess()
            {
                return base.m_basePrivateField;
            }
        }
    }
