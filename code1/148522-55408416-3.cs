    public class MathExtensionsTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 2, 0)]
        [InlineData(-1, 0, 2, 0)]
        [InlineData(1, 0, 2, 1)]
        [InlineData(2, 0, 2, 2)]
        [InlineData(3, 0, 2, 2)]
        [InlineData(0, 2, 0, 0)]
        [InlineData(-1, 2, 0, 0)]
        [InlineData(1, 2, 0, 1)]
        [InlineData(2, 2, 0, 2)]
        [InlineData(3, 2, 0, 2)]
        public void MustClamp(double value, double bound1, double bound2, double expectedValue)
        {
            value.Clamp(bound1, bound2).Should().Be(expectedValue);
        }
    }
