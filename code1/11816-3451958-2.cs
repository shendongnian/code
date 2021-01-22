    public class Derived : Base
    {
        public int BrokenAccess()
        {
            return base.m_basePrivateField;
        }
    }
