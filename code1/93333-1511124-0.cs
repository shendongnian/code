    public class ReadOnly2DArray<T>
    {
        T[,] _array;
        public ReadOnly2DArray(T[,] arrayToWrap)
        {
            _array = arrayToWrap;
        }
    
        public T this[int x, int y]
        {
            get { return _array[x, y]; }
        }
    }
