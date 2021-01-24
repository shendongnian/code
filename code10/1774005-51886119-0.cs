    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {5, 1, 3, 9},
            new object[] {7, 1, 5, 3}
        };
    
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class ParameterizedTests
    {
        public bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }
    
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void AllNumbers_AreOdd_WithClassData(int a, int b, int c, int d)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
        }
    }
