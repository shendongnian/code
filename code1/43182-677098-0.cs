    public class AContainerClass
    {
        SomeDisposableObject m_someObject; // No creation here.
        public AContainerClass(SomeDisposableObject someObject)
        {
            m_someObject = someObject;
        }
        public SomeDisposableObject SomeObject
        {
            get { return m_someObject; }
            set { m_someObject = value; }
        }
    }
