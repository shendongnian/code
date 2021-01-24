    public class MyRegistrations : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<Thing>();
        // and all your other registrations.
      }
    }
