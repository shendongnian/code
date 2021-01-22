    public class NotAString
    {
        private string m_RealString = string.Empty;
        public new Type GetType()
        {
            return m_RealString.GetType();
        }
    }
