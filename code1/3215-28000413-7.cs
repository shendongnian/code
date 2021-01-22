    class SomeData
    {
        public SomeData() { }
        static public IEnumerable<SomeData> CreateSomeDatas()
        {
            yield return new SomeData();
            yield return new SomeData();
            yield return new SomeData();
        }
    }
