    private class EmptyEnumerator : IEnumerator
    {
        public EmptyEnumerator()
        {
        }
    
        #region IEnumerator Members
    
        public void Reset(){}
    
        public object Current
        {
            get
            {
                return null;
            }
        }
    
    
    public class EmptyEnumerable : IEnumerable
    {
        
        public IEnumerator GetEnumerator()
        {
            return new EmptyEnumerator();
        }    
    }
