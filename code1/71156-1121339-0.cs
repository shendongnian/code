        public interface ISomeData<T> where T: IEnumerable<string>
        {
            T Data { get; }
        }
        public class MyData : ISomeData<List<string>>
        {
            private List<string> m_MyData = new List<string>();
            public List<string> Data { get { return m_MyData; } }
        }
