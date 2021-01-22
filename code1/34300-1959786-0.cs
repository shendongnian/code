    class TypeToTest
    {
        public void Method() { }
    }
    interface ITypeToTest
    {
        void Method() { }
    }
    class TypeToTestProxy : ITypeToTest
    {
        TypeToTest m_type = new TypeToTest();
        public void Method() { m_type.Method(); }
    }
