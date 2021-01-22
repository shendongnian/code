    /// <summary>Method for testing the performance of several options to determine if a type is     nullable</summary>
    [TestMethod]
    public void IdentityNullablePerformanceTest()
    {
        int attempts = 1000000;
        Type nullableType = typeof(Nullable<int>);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int attemptIndex = 0; attemptIndex < attempts; attemptIndex++)
        {
            Assert.IsTrue(Nullable.GetUnderlyingType(nullableType) != null, "Expected to be a nullable"); 
        }
        Console.WriteLine("Nullable.GetUnderlyingType(): {0} ms", stopwatch.ElapsedMilliseconds);
            
        stopwatch.Restart();
        for (int attemptIndex = 0; attemptIndex < attempts; attemptIndex++)
       {
           Assert.IsTrue(nullableType.IsGenericType && nullableType.GetGenericTypeDefinition() == typeof(Nullable<>), "Expected to be a nullable");
       }
       Console.WriteLine("GetGenericTypeDefinition() == typeof(Nullable<>): {0} ms", stopwatch.ElapsedMilliseconds);
       stopwatch.Stop();
    }
