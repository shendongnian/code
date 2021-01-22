    public interface IStateSpace
    {
        IState GetStateAt(IPosition position);
        void SetStateAt(IPosition position, IState state);
    }
    
    public interface IState
    {
        IStateSpace StateSpace { get; }
        IValue Value { get; set; }
    }
    
    public interface IPosition
    {
    }
    
    public interface IValue
    {
        IState State { get; }
    }
