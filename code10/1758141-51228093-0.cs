    public abstract class StateBase<StatesList, StateData, TChildType>
     where StatesList : class
     where StateData : class
     where TChildType : StateBase<StatesList, StateData, TChildType> //notice addition of TChildType
    {
        public string Name { get; protected set; }
        protected StatesList stateList;
        protected StateData stateData;
        public StateBase(StatesList stateList, StateData stateData)
        {
            Name = this.GetType().Name;
            this.stateList = stateList;
            this.stateData = stateData;
        }
        public abstract bool CanTransitionTo(TChildType newState);
        public abstract void Enter();
        public abstract TChildType Tick();
        public abstract void Exit();
    }
    public class DerivedState : StateBase<string, string, DerivedState>
    {
        ...
    }
