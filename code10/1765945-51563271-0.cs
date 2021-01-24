    public class FooDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"123", null},
            new object[] {"123", 610M}
        };
    
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
