    public class ParentActorA{
        public ParentActorA(){
           Receive<WorkItem>(x => {
              // create new child to carry out the work
              var delegatorActor = Context.ActorOf<ActorA>();
              delegatorActor.Forward(x);
           });
        }
    }
