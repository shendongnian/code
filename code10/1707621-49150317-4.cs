    public interface IOperation
    {
        Output Process(Input input);
        bool AppliesTo(string operation);
    }
    public interface IOperationStrategy
    {
        Output Process(string operation, Input input);
    }
