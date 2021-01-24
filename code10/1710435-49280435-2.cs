    public class Foo
    {
        private IBar _Bar;
        public IBar Bar { get { return _Bar ?? (_Bar = new Bar(this.Context)); } }
    }
