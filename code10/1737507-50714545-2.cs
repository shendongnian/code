    ...
    InterpreterStateMachine _machine = new InterpreterStateMachine();
    InMemorySagaRepository<InterpreterInstance> _repository = new InMemorySagaRepository<InterpreterInstance>();
    ...
    x.ReceiveEndpoint(host, "state_machine", e =>
    {
        e.PrefetchCount = 1;
        //here the state machine is set
        e.StateMachineSaga(_machine, _repository);
        e.Durable = false;
    });
    
