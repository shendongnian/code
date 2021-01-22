    public class MyArray<T> {
        private T[] _list;
        public MyArray() : this.MyArray(10);
        public MyArray(int capacity)
        { _list = new T[capacity]; }
        T this[int index] {
            get { return _list[index]; }
            set { _list[index] = value; }
        }
    }
