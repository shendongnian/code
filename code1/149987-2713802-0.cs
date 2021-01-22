    public State PreviousAction { get; set; }
    public IList<State> States { get; private set }
    public void QueueAction(State CurrentAction)
    {    
        if(PreviousAction != null)
        {        
            States.Add(new State(PreviousAction, CurrentAction)        
        }
        
        PreviousAction = CurrentAction;    
    }
    
    public void Execute()
    {    
        States.Add(new State(PreviousAction, State.Terminator));
        
        States[0].Execute();    
    }
