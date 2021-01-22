    class Program
    {
        static void Main(string[] args)
        {
            //var list = MyClass.DequeueAll().ToList();
            //var list2 = MyClass.DequeueAll().ToList();
            var clonable = MyClass.DequeueAll().ToClonable();
            var list = clonable.Clone().ToList();
            var list2 = clonable.Clone()ToList();
            var list3 = clonable.Clone()ToList();
        }
    }
    class MyClass
    {
        static Queue<string> list = new Queue<string>();
        static MyClass()
        {
            list.Enqueue("one");
            list.Enqueue("two");
            list.Enqueue("three");
            list.Enqueue("four");
            list.Enqueue("five");
        }
        public static IEnumerable<string> DequeueAll()
        {
            while (list.Count > 0)
                yield return list.Dequeue();
        }
    }
    static class Extensions
    {
        public static IClonableEnumerable<T> ToClonable<T>(this IEnumerable<T> e)
        {
            return new ClonableEnumerable<T>(e);
        }
    }
    class ClonableEnumerable<T> : IClonableEnumerable<T>
    {
        List<T> items = new List<T>();
        IEnumerator<T> underlying;
        public ClonableEnumerable(IEnumerable<T> underlying)
        {
            this.underlying = underlying.GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new ClonableEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private object GetPosition(int position)
        {
            if (HasPosition(position))
                return items[position];
            throw new IndexOutOfRangeException();
        }
        private bool HasPosition(int position)
        {
            lock (this)
            {
                while (items.Count <= position)
                {
                    if (underlying.MoveNext())
                    {
                        items.Add(underlying.Current);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public IClonableEnumerable<T> Clone()
        {
            return this;
        }
        class ClonableEnumerator<T> : IEnumerator<T>
        {
            ClonableEnumerable<T> enumerable;
            int position = -1;
            public ClonableEnumerator(ClonableEnumerable<T> enumerable)
            {
                this.enumerable = enumerable;
            }
            public T Current
            {
                get
                {
                    if (position < 0)
                        throw new Exception();
                    return (T)enumerable.GetPosition(position);
                }
            }
            public void Dispose()
            {
            }
            object IEnumerator.Current
            {
                get { return this.Current; }
            }
            public bool MoveNext()
            {
                if(enumerable.HasPosition(position + 1))
                {
                    position++;
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                position = -1;
            }
        }
    }
    interface IClonableEnumerable<T> : IEnumerable<T>
    {
        IClonableEnumerable<T> Clone();
    }
