    public interface ISomeData : IEnumerable<string>
    {
        IEnumerable<string> Data { get; }
    }
    
    public class MyData : ISomeData
    {
        private List<string> m_MyData = new List<string>();
        public List<string> Data { get { return m_MyData; }
        
        public IEnumerator<string> GetEnumerator()
        {
    	    return Data;
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        	return GetEnumerator();
        }
    }
