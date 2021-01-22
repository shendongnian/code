    static void ExpectException<T>(Action action) 
        where T : Exception
    {
        try
        {
            action();
            Assert.Fail("Expected exception " + typeof(T));
        }
        catch (T)
        {
            // Expected
        }
    }
