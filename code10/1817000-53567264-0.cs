    public class AManager : DomainService, IAManager
    {
        public void CreateA()
        {
            var a = new A();
            Repository.Insert(a);
            EventBus.Trigger(new EntityCreatingBeforeSaveEventData<A>
            {
                 Property = a.SomeProperty // Can pass other properties
            });
        }
    }
    public class BManager : DomainService, IBManager
    {
        // Similar to above
    }
