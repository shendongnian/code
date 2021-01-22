    public class MyData : ISomeData
    {
        private List<string> m_MyData = new List<string>();
        public List<string> Data
        {
            get
            {
                return m_MyData;
            }
        }
        #region ISomeData Members
        IEnumerable<string> ISomeData.Data
        {
            get
            {
                return Data.AsEnumerable<string>();
            }
        }
        #endregion
    }
