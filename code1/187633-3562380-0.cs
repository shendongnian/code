    private static void Crash()
    {
        bool testCrash2 = testCrash;
        try { }
        finally
        {
            HttpRuntime.Cache.Insert("xxx", testCrash2);
        }
    }
