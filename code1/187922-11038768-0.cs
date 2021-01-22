    public class AltEnumerator : System.Collections.IEnumerable
    {
        private System.Collections.IEnumerator _base;
        public AltEnumerator(System.Collections.IEnumerator _pbase)
        {
            _base = _pbase;
        }
        #region IEnumerable Members
        public System.Collections.IEnumerator GetEnumerator()
        {
            return _base ;
        }
        #endregion
    }
