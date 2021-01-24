    public class Answer
    {
        public Answer()
        {
            // Have your service collection, register everything you need
            // before having to add your custom service.
            var collection = new ServiceCollection()
                .AddSingleton<ISpecialService, Service3>();
                //---
            // Build a temporary container without your custom service
            var provider = collection.BuildServiceProvider();
            // Use that container to call your instance of your custom service
            var serviceInstanceWithDI = provider.GetService<ISpecialService>();
            // This way the service is pulled from the DI container with all of its 
            // dependencies injected, assuming they are registered beforehand
            // Add it back to the collection with its dependencies already injected
            collection.AddSingleton<Service3, Service3>(serviceInstanceWithDI);
            // Change name, move to Colombia and become a lawyer
        }
    }
