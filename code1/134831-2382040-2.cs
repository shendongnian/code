    public class ShiftyArray<T>
    {
        private readonly T[] array;
        private int front;
        public ShiftyArray(T[] array)
        {
            this.array = array;
            front = 0;
        }
        public void ShiftLeft()
        {
            array[front++] = default(T);
            if(front > array.Length - 1)
            {
                front = 0;
            }
        }
        public void ShiftLeft(int count)
        {
            for(int i = 0; i < count; i++)
            {
                ShiftLeft();
            }
        }
        public T this[int index]
        {
            get
            {
                if(index > array.Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[(front + index) % array.Length];
            }
        }
        public int Length { get { return array.Length; } }
    }
