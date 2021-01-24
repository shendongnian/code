            var builder = new ContainerBuilder();
            builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>();
            builder.RegisterType<DateTimeUtcProvider>().As<IDateTimeUtcProvider>();
            builder.RegisterType<ServiceBoth>();
            builder.RegisterType<Service>();
            builder.RegisterType<UtcService>();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var sb = scope.Resolve<ServiceBoth>();
                var s = scope.Resolve<Service>();
                var su = scope.Resolve<UtcService>();
                Console.WriteLine($"Both: {sb.Dt}, {sb.UtcDt}; Norm: {s.Dt}; Utc: {su.Dt}");
                Console.ReadLine();
            }
