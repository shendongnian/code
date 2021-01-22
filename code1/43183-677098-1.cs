    public class AContainerClass: IDisposable
    {
        SomeDisposableObject m_someObject = new SomeDisposableObject();
        public SomeDisposableObject SomeObject
        {
            get { return m_someObject; }
            set 
            {
                if (m_someObject != null && m_someObject != value)
                    m_someObject.Dispose();
                m_someObject = value;
            }
        }
        public void Dispose()
        {
            if (m_someObject != null)
                m_someObject.Dispose();
            GC.SuppressFinalize(this);
        }
    }
