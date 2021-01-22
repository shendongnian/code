    interface IStateSpace
    {
        IValue GetStateAt(IPosition position);
        void SetStateAt(IPosition position, IState state);
    }
    
    interface IState
    {
        IStateSpace StateSpace { get; }
        IValue Value { get; set; }
    }
    
    interface IPosition
    {
    }
    
    interface IValue
    {
        IState State { get; }
    }
