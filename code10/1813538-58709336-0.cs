    public class UpdateCoordinator : ReceiveActor
    {
        //all your update referenced
        private readonly Dictionary<int, IActorRef> _updates;
        public UpdateCoordinator()
        {
            _updates = new Dictionary<int, IActorRef>();
            //create the update reference
            Receive<UpdateMessage>(updateMessage =>
            {
                //add to the list of actors
                CreateUpdateReferenceIfNotExists(updateMessage.Identifier);
                IActorRef childUpdateRef = _updates[updateMessage.Identifier];
                //start your update actor
                childUpdateRef.Tell(updateMessage);
            });
        }
        private void CreateUpdateReferenceIfNotExists(int identifier)
        {
            if (!_updates.ContainsKey(identifier))
            {
                IActorRef newChildUpdateRef = Context.ActorOf(Props.Create(()=> new UpdateActor(identifier)), $"Update_{identifier}");
                _updates.Add(identifier, newChildUpdateRef);
            }
        }
    }
