    public class C<T> where T : A<double>
    {
        public C(T thing)
        {
            _thing = thing;
        }
        protected T _thing;
    }
