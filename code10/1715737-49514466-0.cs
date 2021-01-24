    public class OperationStrategy : IOperationStrategy
    {
    	// paramaterless ctor
        public OperationStrategy()
        { }
    
        public OperationStrategy(params IOperation[] operations)
        {
            if (operations == null)
                throw new ArgumentNullException(nameof(operations));
            this.operations = operations;
        }
    
        public Output Process(Type type, Input input)
        {
            var op = operations.FirstOrDefault(o => o.AppliesTo(type));
    
            if (op == null)
                throw new InvalidOperationException($"{operation} not registered.");
    
            return op.Process(input);
        }
    
        //property - this can be deserialized by Hangfire
        public List<IOperation> Operations {get; set;}
    }
