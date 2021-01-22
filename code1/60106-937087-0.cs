    public MyOtherClass<T> : MyBaseClass<T> where T : class, IMyInterface
    {
        public IQueryable<T> ShowThisMethod()
        {
            // stuff.
        }
    }
