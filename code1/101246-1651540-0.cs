    class Base
    {
        public Base(int[] xs) {}
    }
    
    class Derived : Base
    {
        public Derived(int first, int last)
            : base(
                ((Func<int[]>)delegate
                {
                    List<int> xs = new List<int>();
                    for (int x = first; x < last; ++x)
                    {
                        xs.Add(x);
                    }
                    return xs.ToArray();
                })())
        {
        }
    }
