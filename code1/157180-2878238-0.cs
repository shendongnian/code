    public interface IAction<State, Action>
        where State : IState
        where Action: IAction<State, Action>
    {
        IStateSpace<State, Action> StateSpace { get; }
    }
