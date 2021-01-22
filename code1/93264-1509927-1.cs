    public class Container
    {
        public A A { get; private set; }
        public B B { get; private set; }
        public C C { get; private set; }
        private bool TestProp<T>(object o, Action<T> f)
        {
            if (o is T)
                return false;
            
            f((T)o);
            return true;
        }
        public bool StoreIfKnown(object o)
        {
            return
                TestProp<A>(o, x => A = x) ||
                TestProp<B>(o, x => B = x) ||
                TestProp<C>(o, x => C = x) ||
                false;
        }
    }
