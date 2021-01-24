    public class AHandler : IEventHandler<EntityCreatingBeforeSaveEventData<A>>, ITransientDependency
    {
        public IBManager BManager { get; set; }
        public void HandleEvent(EntityCreatingBeforeSaveEventData<A> eventData)
        {
            var aSomeProperty = eventData.Property;
            BManager.CreateB();
        }
    }
