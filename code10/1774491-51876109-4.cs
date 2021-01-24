        // Build Windsor container
        using (var container = new WindsorContainer())
        {
            // Install DI abstraction layer
            container.Install(new DependencyInjectionInstaller());
            
            // Install cluster abstraction layer
            container.Install(new IgniteInstaller());
            
            // Attach DI container to cluster plugin
            container
                .Resolve<IIgnite>()
                .GetPlugin<DependencyInjectionPlugin>("DependencyInjection")
                .Container = container.Resolve<IContainer>();
            // Wait
            Done.Wait();
        }
