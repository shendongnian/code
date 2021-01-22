    public class Foo
    {
        private readonly LazyInit<Bar> _bar1 = LazyInit<Bar>.Create<Bar>();
        private readonly LazyInit<Bar> _bar2 = new LazyInit<Bar>(() => new Bar("foo"));
        public Bar Bar1
        {
            get { return _bar1.Instance; }
        }
        public Bar Bar2
        {
            get { return _bar2.Instance; }
        }
    }
