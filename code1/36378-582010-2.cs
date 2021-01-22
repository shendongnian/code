    public SomeClass
    {
        [Dependency]
        public ITest test { get; set; }
        // not the best, but should still work due to finalizer.
        public string Method1(int value)
        {
            return this.test.TestMethod(value);
        }
        // the good way to do it
        public string Method2(int value)
        {
            using(ITest t = unityContainer.Resolve<ITest>())
            {
                return t.TestMethod(value);
            }
        }
    }
