        public class FixedArray<T>
        {
            private T[] array;
            public int Length { get { return array.Length; } }
            public FixedArray (int size)
	        {
                array = new T[size];
	        }
            public T this[int index]
            {
                get { return array[index]; }
                set { array[index] = value; }
            }
        }
