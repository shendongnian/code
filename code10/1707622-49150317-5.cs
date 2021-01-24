    public class Add : IOperation
    {
        public bool AppliesTo(string operation)
        {
            return nameof(Add).Equals(operation, StringComparison.OrdinalIgnoreCase);
        }
        public Output Process(Input input)
        {
            // Implementation
            return new Output();
        }
    }
    public class Multiply : IOperation
    {
        public bool AppliesTo(string operation)
        {
            return nameof(Multiply).Equals(operation, StringComparison.OrdinalIgnoreCase);
        }
        public Output Process(Input input)
        {
            // Implementation
            return new Output();
        }
    }
