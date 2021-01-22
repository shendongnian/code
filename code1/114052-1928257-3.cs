    class Matrix2<T>
    {
        private T[][] _data;
        private int _columns;
        public Matrix2(int rows, int cols)
        {
            _data = new T[rows][];
            _columns = cols;
            for (int i = 0; i < rows; i++) _data[i] = new T[cols];
        }
        public T this [int x]
        {
            get { return _data [x/_columns][x % _columns]; }
            set { _data [x/_columns][x % _columns] = value; }
        }
        public T[] Row(int r)
        {
            return _data [r];
        }
    }
