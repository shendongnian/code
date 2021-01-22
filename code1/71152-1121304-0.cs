    public class MyData : ISomeData
    {
        private List<string> m_MyData = new List<string>();
        public IEnumerable<string> Data { get { return m_MyData; } }
    }
