    public class IsAuthorizedAttribute : CodeAccessSecurityAttribute
    {
        // set mock here in the test initialization.
        // I assume external accessor can be a static field.
        private static ExternalAccessor m_accessor = new ExternalAccessor();
        private static bool IsAuthorised(string entityObject, string field, char expected, ServicesConfiguration servicesConfiguration)
        {
            return m_accessor.Check();
        }
    }
    public class ExternalAccessor
    {
        private bool m_initialized;
        private void Setup()
        {
            // setup
            m_initialized = true;
        }
        public virtual bool Check()
        {
            // You can call setup anytime but the constructor.
            if (!m_initialized) { Setup(); }
            // check external stuff
        }
    }
