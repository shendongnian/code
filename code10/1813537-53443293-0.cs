      public class MyActor : ActorBase, IWithUnboundedStash
      {
         public IStash Stash { get; set; }
         public Receive Active(State workUnit) => message =>
         {
            switch(message)
            {
               case DoWork: 
                  // stash all messages not related to current work
                  Stash.Stash(message); 
                  return true;
               case WorkDone done:
                  // when current unit of work is done, unstash pending messages
                  Stash.UnstashAll();
                  Become(Idle);
                  return true;
            }
         };
         public bool Idle(object message)
         {
            switch(message)
            {
               case DoWork work: 
                  StartWork(work.State);
                  Become(Active(work.State)); //continue work in new behavior
                  return true;
               default: 
                  return false;
            }
         } 
         public bool Receive(object message) => Idle(message);
      }
