    public class CustomList<T>
    {
        private T[] MyArray { get; set; }
        // We don't want them being able to set the size of our array do we? 
        public int Count { get; private set; }
        public CustomList()
        {
            MyArray = new T[0];
            Count = 0;
        }
        // Add Value
        public T[] Add(T value)
        {
            // Because we are adding a item, add one to the count
            Count++;
            // Copy the old array so we do not lose any values
            var copyArray = MyArray;
            // Reinitialize the Array to the new size
            MyArray = new T[Count];
            // Iterate through each item and add it to the array
            for (var index = 0; index < copyArray.Length; index++)
            {
                MyArray[index] = copyArray[index];
            }
            // Subtract one from count because Arrays start at 0
            // Add the new value
            MyArray[Count - 1] = value;
            return MyArray;
        }
    }
