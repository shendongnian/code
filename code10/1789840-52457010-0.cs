    public class CalculatorTestData
    {
        public CalculatorTestData(int x, int y, int expected)
        {
            X = x;
            Y = y;
            Expected = expected;
        }
        public int X { get; }
        public int Y { get; }
        public int Expected { get; }
        /// <inheritdoc />
        public override string ToString()
        {
            return $"Multiply {X} and {Y} should be {Expected}";
        }
    }
