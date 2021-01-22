       foreach (int k in Fibonacci.Create(10))
           Console.WriteLine(k);
        class Fibonacci : IEnumerable<int>
        {
            private FibonacciEnumertor fibEnum;
            public Fibonacci(int max) {
                fibEnum = new FibonacciEnumertor(max);
            }
            public IEnumerator<int> GetEnumerator() {
                return fibEnum;
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }
            public static IEnumerable<int> Create(int max) {
                return new Fibonacci(max);
            }
            private class FibonacciEnumertor : IEnumerator<int>
            {
                private int a, b, c, max;
                public FibonacciEnumertor(int max) {
                    this.max = max;
                    Reset();
                }
                // 1 1 2 3 5 8
                public int Current {
                    get {
                        return c;
                    }
                }
                public void Dispose() {
                }
                object System.Collections.IEnumerator.Current {
                    get { return this.Current; }
                }
                public bool MoveNext() {
                    c = a + b;
                    if (c == 0)
                        c = 1;
                    a = b;
                    b = c;
                    ;
                    return max-- > 0;
                }
                public void Reset() {
                    a = 0;
                    b = 0;
                }
            }
        }
