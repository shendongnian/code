    public class EnumeratorExample : IEnumerator
    {
        string[] _array;
    
        // enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;
    
        public EnumeratorExample(string[] array)
        {
            _array = list;
        }
    
        public bool MoveNext()
        {
            ++position;
            return (position < _array.Length);
        }
    
        public void Reset()
        {
            position = -1;
        }
    
        object IEnumerator.Current
        {
            get { return Current; }
        }
    
        public string Current
        {
            get
            {
                try
                {
                    return _array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("Enumerator index was out of range. Position: " + position + " is greater than " + _array.Length);
                }
            }
        }
    }
