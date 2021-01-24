    public class MyAreaContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            AssertRequiredRegistrations();
            Container.RegisterType<IDoesSomething, DoesSomething>();
        }
        private void AssertRequiredRegistrations()
        {
            AssertRequiredRegistration(typeof(ISomeOtherType));
        }
        private void AssertRequiredRegistration(Type type)
        {
            if(!Container.IsRegistered(type)) 
                throw new Exception($"Type {type.FullName} must be registered with the container.");
        }
    }
