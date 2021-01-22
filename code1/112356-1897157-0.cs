    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TableProperty : Attribute
    {
        private string m_include;
        private string[] m_includeSplit;
        public TableProperty()
        {
            m_includeSplit = new string[0];
        }
        public string Include
        {
            get
            {
                return (m_include ?? string.Empty);
            }
            set
            {
                m_include = value;
                m_includeSplit = value.Split(',');
            }
        }
        public bool IsPropertyAllowed(string propertyName)
        {
            return IsPropertyAllowed(propertyName, m_includeSplit);
        }
        internal static bool IsPropertyAllowed(string propertyName, string[] includeProperties)
        {
            return ((includeProperties == null) || (includeProperties.Length == 0)) || includeProperties.Contains<string>(propertyName, StringComparer.OrdinalIgnoreCase);
        }
    }
