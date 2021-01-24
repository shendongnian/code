    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            // Add callback which hooks up Activated event.
            builder
                .RegisterBuildCallback(builtContainer =>
                {
                    var iSomethingRegistrations = builtContainer
                        .ComponentRegistry
                        .Registrations
                        .Where(registration => IsISomething(registration.Activator.LimitType))
                        .ToList();
                    Console.WriteLine($"Found {iSomethingRegistrations.Count} ISomething Registrations");
                    foreach (var iSomethingRegistration in iSomethingRegistrations)
                    {
                        iSomethingRegistration.Activated += (sender, eventArgs) =>
                        {
                            Console.WriteLine($"ISomething {eventArgs.Instance.GetType().Name} Activated");
                        };
                    }
                });
            // Register services
            builder.RegisterType<Foo>().As<IFoo>().SingleInstance();
            builder
                .RegisterType<Bar>()
                .As<IBar>()
                .SingleInstance();
                //.AutoActivate()
                //.OnActivated(eventArgs => Console.WriteLine($"IBar local Activated"));
            builder.RegisterType<Baz>();
            // Build container
            var container = builder.Build();
            // Resolve service
            var baz = container.Resolve<Baz>();
            var bar = container.Resolve<IBar>();
            Console.ReadLine();
        }
        private static bool IsISomething(Type type)
            => (type == typeof(ISomething))
            || type.GetInterfaces().Any(interfaceType => interfaceType == typeof(ISomething));
    }
