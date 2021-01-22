    public abstract class StringList : IEnumerable<string>
    {
        private string[] _list = new string[] {"foo", "bar", "baz"};
        // ...
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string s in _list)
            { yield return s; }
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
