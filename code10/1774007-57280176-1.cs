    public class ParameterizedTests: IClassFixture<TFixture>
    {
        public ParameterizedTests(TFixture fixture)
        {
        }
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
