    // No idea what the naming convention for the generated class is --
    // this is really just a shot in the dark.
    class GetIEnumerable_Enumerator : IEnumerator<string>
    {
        int _state;
        string _current;
    
        public bool MoveNext()
        {
            switch (_state++)
            {
                case 0:
                    _current = "a";
                    break;
                case 1:
                    _current = "a";
                    break;
                case 2:
                    _current = "a";
                    break;
                default:
                    return false;
            }
    
            return true;
        }
    
        public string Current
        {
            get { return _current; }
        }
    
        object IEnumerator.Current
        {
            get { return Current; }
        }
    
        void IEnumerator.Reset()
        {
            // not sure about this one -- never really tried it...
            // I'll just guess
            _state = 0;
            _current = null;
        }
    }
    
    class GetIEnumerable_Enumerable : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            return new GetIEnumerable_Enumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
