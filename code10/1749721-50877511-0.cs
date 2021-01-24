    public class CustomList<T>
    {
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public T[] Add(T value)
        {// add value to array
            T[] myArray = new T[Count];
            myArray.Insert(0, value);
            return myArray;
        }
        public T[] Remove(T value)
        {
            //Find value in array and delete it
        }
    }
