    public class UnionBase<A>
    {
        dynamic value;
        
        public UnionBase(A a) { value = a; } 
        protected UnionBase(object x) { value = x; }
        protected T InternalMatch<T>(params Delegate[] ds)
        {
            var vt = value.GetType();    
            foreach (var d in ds)
            {
                var mi = d.Method;
                
                // These are always true if InternalMatch is used correctly.
                Debug.Assert(mi.GetParameters().Length == 1);
                Debug.Assert(typeof(T).IsAssignableFrom(mi.ReturnType));
                var pt = mi.GetParameters()[0].ParameterType;
                if (pt.IsAssignableFrom(vt))
                    return (T)mi.Invoke(null, new object[] { value });
            }
            throw new Exception("No appropriate matching function was provided");
        }
     
        public T Match<T>(Func<A, T> fa) { return InternalMatch<T>(fa); }
    }
    public class Union<A, B> : UnionBase<A>
    {
        public Union(A a) : base(a) { }
        public Union(B b) : base(b) { }
        protected Union(object x) : base(x) { }
        public T Match<T>(Func<A, T> fa, Func<B, T> fb) { return InternalMatch<T>(fa, fb); }
    }
    public class Union<A, B, C> : Union<A, B>
    {
        public Union(A a) : base(a) { }
        public Union(B b) : base(b) { }
        public Union(C c) : base(c) { }
        protected Union(object x) : base(x) { }
        public T Match<T>(Func<A, T> fa, Func<B, T> fb, Func<C, T> fc) { return InternalMatch<T>(fa, fb, fc); }
    }
    public class Union<A, B, C, D> : Union<A, B, C>
    {
        public Union(A a) : base(a) { }
        public Union(B b) : base(b) { }
        public Union(C c) : base(c) { }
        public Union(D d) : base(d) { }
        protected Union(object x) : base(x) { }
        public T Match<T>(Func<A, T> fa, Func<B, T> fb, Func<C, T> fc, Func<D, T> fd) { return InternalMatch<T>(fa, fb, fc, fd); }
    }
    public class Union<A, B, C, D, E> : Union<A, B, C, D>
    {
        public Union(A a) : base(a) { }
        public Union(B b) : base(b) { }
        public Union(C c) : base(c) { }
        public Union(D d) : base(d) { }
        public Union(E e) : base(e) { }
        protected Union(object x) : base(x) { }
        public T Match<T>(Func<A, T> fa, Func<B, T> fb, Func<C, T> fc, Func<D, T> fd, Func<E, T> fe) { return InternalMatch<T>(fa, fb, fc, fd, fe); }
    }
    public class DiscriminatedUnionTest : IExample
    {
        public Union<int, bool, string, int[]> MakeUnion(int n)
        {
            return new Union<int, bool, string, int[]>(n);
        }
        public Union<int, bool, string, int[]> MakeUnion(bool b)
        {
            return new Union<int, bool, string, int[]>(b);
        }
        public Union<int, bool, string, int[]> MakeUnion(string s)
        {
            return new Union<int, bool, string, int[]>(s);
        }
        public Union<int, bool, string, int[]> MakeUnion(params int[] xs)
        {
            return new Union<int, bool, string, int[]>(xs);
        }
        public void Print(Union<int, bool, string, int[]> union)
        {
            var text = union.Match(
                n => "This is an int " + n.ToString(),
                b => "This is a boolean " + b.ToString(),
                s => "This is a string" + s,
                xs => "This is an array of ints " + String.Join(", ", xs));
            Console.WriteLine(text);
        }
        public void Run()
        {
            Print(MakeUnion(1));
            Print(MakeUnion(true));
            Print(MakeUnion("forty-two"));
            Print(MakeUnion(0, 1, 1, 2, 3, 5, 8));
        }
    }
