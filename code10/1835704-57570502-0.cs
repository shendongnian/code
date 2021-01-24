       public static class ContextFactory
        {
            public static SampleContextCreateInMemoryContractContext()
            {
                var options = new DbContextOptionsBuilder<SchedulingContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;
    
    
                return new SampleContext(options);
            }
         }
