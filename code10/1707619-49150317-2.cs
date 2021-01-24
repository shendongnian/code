    public class OperationStrategy : IOperationStrategy
    {
        private readonly IOperation[] operations;
        public OperationStrategy(params IOperation[] operations)
        {
            if (operations == null)
                throw new ArgumentNullException(nameof(operations));
            this.operations = operations;
        }
        public Output Process(string operation, Input input)
        {
            var op = operations.FirstOrDefault(o => o.AppliesTo(operation));
            if (op == null)
                throw new InvalidOperationException($"{operation} not registered.");
            return op.Process(input);
        }
    }
