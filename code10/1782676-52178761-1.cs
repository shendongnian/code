    public interface baseInterface <T> where T : IEnumerable<double>
        {
            T Data { get; set; }
        }
        public class derivedInterface : baseInterface <List<double>>
        {
            private List<double> m_Data = new List<double>();
            public List<double> Data { get { return m_Data; } 
            set { this.m_MyData = value; }}
        }
