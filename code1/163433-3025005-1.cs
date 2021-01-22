    class BIWebServiceResult<T>
    {
        private readonly Func<string,T> m_ValueParser;  
  
        public BIWebServiceResult( Func<string,T> valueParser )
        {
            m_ValueParser = valueParser;
        }
        public void SetData(string Input, StringToStatusCode StringToError) 
        {
            Data = m_ValueParser( Input );   // use supplied conversion func
            //...
        }
    }
