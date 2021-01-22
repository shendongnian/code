    // error checking omitted
    class MatrixWrapper<T>
    {
        private T[] _data;
        private int _columns;
        public MatrixWrapper(T[] data, int rows, int columns)
        {
            _data = data;
            _columns = columns;
            // validate rows * columns == length
        }
        public T this[int r, int c]
        {
            get { return _data[Index(r, c)]; }
            set { _data[Index(r, c)] = value; }
        }
        private int Index(int r, int c)
        {
            return r * _columns + c;
        }
    }
