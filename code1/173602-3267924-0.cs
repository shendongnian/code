    public class OriginalClassDestroyNotifier : OriginalClass
    {
        private readonly Guid _instanceId;
        public OriginalClassDestroyNotifier(Guid instanceId)
        {
            _instanceId = instanceId;
        }
        ~OriginalClassDestroyNotifier()
        {
            FactoryRepository.NotifyDestroyed(_instanceId);
        }
    }
 
