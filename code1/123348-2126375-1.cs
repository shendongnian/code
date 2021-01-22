    internal class MockedDiceRoller : IDiceRoller
    {
        public int Value { get; set; }
    
        public int GetValue(int lowerBound, int upperBound)
        {
            return this.Value;
        }
    }
