    class SomeData
    {
        public SomeData() { }
        static public IEnumerable<SomeData> CreateSomeDatas()
        {
            return new List<SomeData> {
                new SomeData(), 
                new SomeData(), 
                new SomeData()
            };
        }
    }
