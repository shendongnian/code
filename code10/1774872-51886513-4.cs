    abstract class Test
    {
        private IClass _actor;
        public IClass Actor
        {
            get {
                if (_actor == null) {
                    _actor = CreateActor();
                }
                return _actor;
            }
        }
        public MyEnum eEnum { get; set; }
        public string Str { get; set; }
        protected abstract IClass CreateActor(); // We implement it in the generic class.
    }
    class Test<T> : Test
        where T : IClass, new()
    {
        public new T Actor // Hides inherited member.
        {
            get { return (T)base.Actor;  }
        }
        protected override IClass CreateActor()
        {
            return new T();
        }
    }
