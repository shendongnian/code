    public class MyAreaContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDoesSomething, DoesSomething>();
        }
    }
