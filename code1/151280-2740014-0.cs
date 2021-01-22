    IEnumerable<int> Numbers()
    {
        return new PrivateNumbersEnumerable();
    }
    
    private class PrivateNumbersEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator() 
        { 
            return new PrivateNumbersEnumerator(); 
        }
    }
    
    private class PrivateNumbersEnumerator : IEnumerator<int>
    {
        private int i;
        public bool MoveNext() { i++; return true; }   
        public int Current
        {
            get { return i; }
        }
    }
