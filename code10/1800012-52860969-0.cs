            //Lighweight registration
            containerBuilder.RegisterType<TestItem>().As<ITestItem>();
            //Actual regirstation
            containerBuilder.Register((c, qe) =>
            {
                var subType = c.Resolve<IsubType>();
                return new TestItem(subType);
            }).As<ITestItem>().Keyed("TestKey", typeof(ITestItem));
            containerBuilder.RegisterBuildCallback(builtContainer =>
            {
                //Filter for types
                foreach (var registration in builtContainer.ComponentRegistry.Registrations)
                {
                    registration.Activating += (sender, eventArgs) =>
                     {
                         var instanseLookup = eventArgs.Context as IInstanceLookup;
                         if (instanseLookup != null && !instanseLookup.ActivationScope.Tag.Equals("Manual"))
                         {
                             var scope = builtContainer.BeginLifetimeScope("Manual");
                             eventArgs.Instance = scope.ResolveKeyed<ITestItem>("TestKey");
                         }
                     };
                }
            });
