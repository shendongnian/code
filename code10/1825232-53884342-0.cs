    public class EntityOperationProvider {
        private readonly IEntityOperationCommand _TWCommandPrepare = null;
        private readonly IEntityOperationCommand _TWCommandCreateDetails = null;
        private readonly IEntityOperationCommand _TWCommandPostCreation = null;
        private readonly IEntityOperationCommand _TWCommandRaiseEvents = null;
        private readonly IEntityOperationCommand _TWCommandNotification = null;
        public EntityOperationProvider(IEnumerable<IEntityOperationCommand> commands) {            
            _TWCommandPrepare = commands.OfType<PrepareEntity>().FirstOrDefault();
            _TWCommandCreateDetails = commands.OfType<CreateDetails>().FirstOrDefault();
            _TWCommandPostCreation = commands.OfType<PostCreation>().FirstOrDefault();
            _TWCommandRaiseEvents = commands.OfType<RaiseEvents>().FirstOrDefault();
            _TWCommandNotification = commands.OfType<SendNotification>().FirstOrDefault();
        }
        
        //...
    }
