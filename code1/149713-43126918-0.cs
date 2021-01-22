        public interface SomeInterface
        {
            int Foo { get; set; }
        }
        public class SomeImplementation: SomeInterface
        {
            public int Foo { get; set; }
        }
        static void Main(string[] args)
        {
            UnityContainer iocContainer = new UnityContainer();
            string registerName = "instance";
            //before any registration
            Resolve<SomeInterface>(iocContainer, registerName);
            iocContainer.RegisterInstance<SomeInterface>(registerName, new SomeImplementation());
            //after registration
            Resolve<SomeInterface>(iocContainer, registerName);
            ClearValue<SomeInterface>(iocContainer, registerName);
            //after clear value
            Resolve<SomeInterface>(iocContainer, registerName);
        }
        private static void Resolve<T>(UnityContainer iocContainer,string name)
        {
            if (iocContainer.IsRegistered<T>(name))
                iocContainer.Resolve<T>(name);
            iocContainer.ResolveAll<T>();
        }
        private static void ClearValue<T>(UnityContainer iocContainer, string name)
        {
            foreach (var registration in iocContainer.Registrations.Where(p => p.RegisteredType == typeof(T)
                && p.Name==name))
            {
                registration.LifetimeManager.RemoveValue();
            }
        }
