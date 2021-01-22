    public class AutoMockingRegistrationSource : IRegistrationSource
    {
        private readonly MockFactory mockFactory;
        public AutoMockingRegistrationSource()
        {
            this.mockFactory = new MockFactory(MockBehavior.Default);
            this.mockFactory.CallBase = true;
            this.mockFactory.DefaultValue = DefaultValue.Mock;
        }
        public MockFactory MockFactory
        {
            get { return this.mockFactory; }
        }
        #region IRegistrationSource Members
        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var swt = service as IServiceWithType;
            if (swt == null)
            {
                yield break;
            }
            var existingReg = registrationAccessor(service);
            if (existingReg.Any())
            {
                yield break;
            }
            var reg = RegistrationBuilder.ForDelegate((c, p) =>
                {
                    var createMethod = 
                        typeof(MockFactory).GetMethod("Create", Type.EmptyTypes).MakeGenericMethod(swt.ServiceType);
                    return ((Mock)createMethod.Invoke(this.MockFactory, null)).Object;
                }).As(swt.ServiceType).CreateRegistration();
            yield return reg;
        }
        #endregion
    }
