    // This is doing the same thing but doing it all by hand. 
    // You could use this method as well to lazily iterate through the 'current' list as well
    // This is probably overkill and substantially more complex
    public class TokenSplitter : IEnumerable<IEnumerable<object>>, IEnumerator<IEnumerable<object>>
    {
        IEnumerator<object> _enumerator;
        IEnumerable<object> _tokens;
        TokenType _target;
        List<object> _current;
        bool _isDone = false;
        public TokenSplitter(IEnumerable<object> tokens, TokenType target)
        {
            _tokens = tokens;
            _target = target;
            Reset();
        }        
        // Cruft from the IEnumerable and generic IEnumerator
        public IEnumerator<IEnumerable<object>> GetEnumerator() { return this; }
       
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
        public IEnumerable<object> Current { get { return _current; } }                
        public void Dispose() { }        
        #region IEnumerator Members
        object System.Collections.IEnumerator.Current { get { return Current; } }
        // See if there is anything left to get
        public bool MoveNext()
        {
            if (_isDone) return false;
            
            FillCurrent();
            return !_isDone;            
        }
        // Reset the enumerators so that you could reuse this structure if you wanted
        public void Reset()
        {
            _isDone = false; 
            _enumerator = _tokens.GetEnumerator();
            _current = new List<object>();
            FillCurrent();
        }
        // Fills the current set of token and then begins the next set
        private void FillCurrent()
        {
            // Try to accumulate as many tokens as possible, this too could be an enumerator to delay the process more
            bool hasNext = _enumerator.MoveNext();
            for( ; hasNext; hasNext = _enumerator.MoveNext())
            {            
                Token token = _enumerator.Current as Token;
                if (token == null || token.TokenType != _target)
                {
                    _current.Add(_enumerator.Current);
                }
                else
                {
                    _current = new List<object>();
                }
            }
            // Continue removing matching tokens and begin creating the next set
            for( ; hasNext; hasNext = _enumerator.MoveNext())
            {
                Token token = _enumerator.Current as Token;
                if (token == null || token.TokenType != _target)
                {
                    _current.Add(_enumerator.Current);
                    break;
                }
            }
            _isDone = !hasNext;
        }
        #endregion
    }
