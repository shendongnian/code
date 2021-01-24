    public class MyArray<T>
    {
        private T[] _array;
        public MyArray(int size)
        {
            _array = new T[size];
        }
        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
    }
    public static class ArrayExtensions
    {
        public static void Foo<T>(this MyArray<T> myArray)
        {
            // ..
        }
    }
    public class ArrayUser
    {
        public ArrayUser()
        {
            var a = new MyArray<int>(10);
            a.Foo(); // does not compile, Foo() is unknown
        }
    }
