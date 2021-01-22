    private class ClassEnumerator : IEnumerator
    {
        private ClassList _classList;
        private int _index;
    
        public ClassEnumerator(ClassList classList)
        {
            _classList = classList;
            _index = -1;
        }
    
        #region IEnumerator Members
    
        public void Reset()
        {
            _index = -1;
        }
    
        public object Current
        {
            get
            {
                return _classList._students[_index];
            }
        }
    
        public bool MoveNext()
        {
            _index++;
            if (_index >= _classList._students.Count)
                return false;
            else
                return true;
        }
    
        #endregion
    }
