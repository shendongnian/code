    public class ResolvedNamedParameterModule : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
                                                              IComponentRegistration registration)
        {
            registration.Preparing += (sender, e) =>
            {
                e.Parameters = new Parameter[] { new ResolvedNamedParameter() }.Concat(e.Parameters);
            };
            base.AttachToComponentRegistration(componentRegistry, registration);
        }
    }
