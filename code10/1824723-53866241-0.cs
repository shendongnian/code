    [StatePersistence(StatePersistence.Persisted)]
    class MyActor : Actor, IMyActor
    {
      public MyActor(ActorService actorService, ActorId actorId)
        : base(actorService, actorId)
      {
      }
      public Task<int> GetCountAsync()
      {
        return this.StateManager.GetStateAsync<int>("MyState");
      }
    } 
