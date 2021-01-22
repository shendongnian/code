    namespace ChunkedEnumerator
    {
        public static class Extensions 
        {
            class ChunkedEnumerator<T> : IEnumerable<T>
            {
                class ChildEnumerator : IEnumerator<T>
                {
                    ChunkedEnumerator<T> parent;
                    int position = -1;
                    bool done = false;
    
    
                    public ChildEnumerator(ChunkedEnumerator<T> parent)
                    {
                        this.parent = parent;
                    }
    
                    public T Current
                    {
                        get
                        {
                            if (position == -1 || done)
                            {
                                throw new InvalidOperationException();
                            }
                            return parent.enumerator.Current;
                        }
                    }
    
                    public void Dispose()
                    {
                        if (!done)
                        {
                            while (MoveNext())
                            {
                            }
                        }
                    }
    
                    object System.Collections.IEnumerator.Current
                    {
                        get { return Current; }
                    }
    
                    public bool MoveNext()
                    {
                        if (position == -1)
                        {
                            // parent moves it
                            position = 0;
                            return true;
                        }
    
                        if (done)
                        {
                            throw new InvalidOperationException();
                        }
    
                        if (position == parent.chunkSize - 1)
                        {
                            done = true;
                        }
                        else
                        {
                            done = !parent.enumerator.MoveNext();
                            position += 1;
                        }
    
                        return !done;
    
                    }
    
                    public void Reset()
                    {
                        // per http://msdn.microsoft.com/en-us/library/system.collections.ienumerator.reset.aspx
                        throw new NotSupportedException();
                    }
                }
    
                IEnumerator<T> enumerator;
                int chunkSize;
    
                public ChunkedEnumerator(IEnumerator<T> enumerator, int chunkSize)
                {
                    this.enumerator = enumerator;
                    this.chunkSize = chunkSize;
                }
    
                public IEnumerator<T> GetEnumerator()
                {
                    return new ChildEnumerator(this);
                }
    
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
    
            public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
            {
                if (chunksize < 1) throw new InvalidOperationException();
    
                using (var enumerator = source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        yield return new ChunkedEnumerator<T>(enumerator, chunksize);
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                int i = 10;
                foreach (var group in Enumerable.Range(1, int.MaxValue).Skip(10000000).Chunk(3))
                {
                    foreach (var n in group)
                    {
                        Console.Write(n);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    if (i-- == 0) break;
                }
                
                Console.ReadKey();
    
    /* Output:
    10000001 10000002 10000003
    10000004 10000005 10000006
    10000007 10000008 10000009
    10000010 10000011 10000012
    10000013 10000014 10000015
    10000016 10000017 10000018
    10000019 10000020 10000021
    10000022 10000023 10000024
    10000025 10000026 10000027
    10000028 10000029 10000030
    10000031 10000032 10000033
    */
            }
    
        }
    }
