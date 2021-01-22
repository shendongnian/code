    using System;
    using System.Collections;
    using System.Collections.Generic;
    class ArrayView<T> : IEnumerable<T>
    {
        private readonly T[] array;
        private readonly int offset, count;
        public ArrayView(T[] array, int offset, int count)
        {
            this.array = array;
            this.offset = offset;
            this.count = count;
        }
        public int Length
        {
            get { return count; }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException();
                else
                    return this.array[offset + index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException();
                else
                    this.array[offset + index] = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = offset; i < offset + count; i++)
                yield return array[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator<T> enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            ArrayView<byte> p1 = new ArrayView<byte>(arr, 0, 5);
            ArrayView<byte> p2 = new ArrayView<byte>(arr, 5, 5);
            Console.WriteLine("First array:");
            foreach (byte b in p1)
            {
                Console.Write(b);
            }
            Console.Write("\n");
            Console.WriteLine("Second array:");
            foreach (byte b in p2)
            {
                Console.Write(b);
            }
            Console.ReadKey();
        }
    }
