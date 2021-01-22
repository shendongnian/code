    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    class Foo
    {
        public struct ArrayIterator<T> : IEnumerator<T>
        {
            private int x, y;
            private readonly int width, height;
            private T[,] data;
            public ArrayIterator(T[,] data)
            {
                this.data = data;
                this.width = data.GetLength(0);
                this.height = data.GetLength(1);
                x = y = 0;
            }
            public void Dispose() { data = null; }
            public bool MoveNext()
            {
                if (++x >= width)
                {
                    x = 0;
                    y++;
                }
                return y < height;
            }
            public void Reset() { x = y = 0; }
            public T Current { get { return data[x, y]; } }
            object IEnumerator.Current { get { return data[x, y]; } }
        }
        public sealed class ArrayEnumerator<T> : IEnumerable<T>
        {
            private readonly T[,] arr;
            public ArrayEnumerator(T[,] arr) { this.arr = arr; }
            public ArrayIterator<T> GetEnumerator()
            {
                return new ArrayIterator<T>(arr);
            }
            System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
            {
                return GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public int[,] data;
        public IEnumerable<int> Basic()
        {
            foreach (int i in data) yield return i;
        }
        public ArrayEnumerator<int> Bespoke()
        {
            return new ArrayEnumerator<int>(data);
        }
        public Foo()
        {
            data = new int[500, 500];
            for (int x = 0; x < 500; x++)
                for (int y = 0; y < 500; y++)
                {
                    data[x, y] = x + y;
                }
        }
        static void Main()
        {
            Test(1); // for JIT
            Test(500); // for real
            Console.ReadKey(); // pause
        }
        static void Test(int count)
        {
            Foo foo = new Foo();
            int chk;
            Stopwatch watch = Stopwatch.StartNew();
            chk = 0;
            for (int i = 0; i < count; i++)
            {
                foreach (int j in foo.Basic())
                {
                    chk += j;
                }
            }
            watch.Stop();
            Console.WriteLine("Basic: " + watch.ElapsedMilliseconds + "ms - " + chk);
            watch = Stopwatch.StartNew();
            chk = 0;
            for (int i = 0; i < count; i++)
            {
                foreach (int j in foo.Bespoke())
                {
                    chk += j;
                }
            }
            watch.Stop();
            Console.WriteLine("Bespoke: " + watch.ElapsedMilliseconds + "ms - " + chk);
        }
    }
