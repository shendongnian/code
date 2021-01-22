    class ImmutableSomething : ISomething
    {
        public readonly int SomeInt;
        public ImmutableSomething(int i)
        {
            SomeInt = i;
        }
        public ImmutableSomething AddValue(int add)
        {
            return new ImmutableSomething(this.SomeInt + add);
        }
    }
