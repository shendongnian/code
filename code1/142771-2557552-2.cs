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
        public Add(int i){
            return new ImmutableSomething(_someInt + i);
        }
    }
