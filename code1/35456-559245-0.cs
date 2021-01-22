    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    static class Program
    {
        static void Main()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int value in EvenNumbers(source))
            {
                Console.WriteLine(value);
            }
        }
    
        public static IEnumerable<int> EvenNumbers(IEnumerable<int> numbers)
        {
            return new EvenEnumerable(numbers);
        }
        class EvenEnumerable : IEnumerable<int>
        {
            private readonly IEnumerable<int> numbers;
            public EvenEnumerable(IEnumerable<int> numbers) {
                this.numbers = numbers;
            }
            public IEnumerator<int> GetEnumerator()
            {
                return new EvenEnumerator(numbers);
            }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
        class EvenEnumerator : IEnumerator<int>
        {
            private readonly IEnumerable<int> numbers;
            public EvenEnumerator(IEnumerable<int> numbers)
            {
                this.numbers = numbers;
            }
            private int current;
            void IEnumerator.Reset() { throw new NotSupportedException(); }
            public int Current { get { return current; } }
            object IEnumerator.Current { get { return Current; } }
            IEnumerator<int> iter;
            public bool MoveNext()
            {
                if (iter == null) iter = numbers.GetEnumerator();
                while (iter.MoveNext())
                {
                    int tmp = iter.Current;
                    if (tmp % 2 == 0)
                    {
                        current = tmp;
                        return true;
                    }
                }
                return false;
            }
            public void Dispose()
            {
                if (iter != null)
                {
                    iter.Dispose();
                    iter = null;
                }
            }
        }
    }
