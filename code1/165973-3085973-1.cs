    public abstract class D<T> where T : A
    {
        protected T _member;
        public void DoSomethingAllTsCanDo()
        {
            _member.DoSomething();
        }
        public abstract void DoSomethingOnlyBAndCCanDo();
    }
