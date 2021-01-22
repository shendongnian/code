    public class ImmutableSomething
    {
        private readonly int _someInt;
        public int SomeInt
        {
            get
            {
                return _someInt;
            }
        }
        public ImmutableSomething(int i)
        {
            _someInt = i;
        }
        public ImmutableSomething Add(int i){
            return new ImmutableSomething(_someInt + i);
        }
    }
