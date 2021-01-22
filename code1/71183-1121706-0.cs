    static void myMethod()
    {
        DoEnvironmentExit(0);
    }
    static void DoEnvironentExit(int code)
    {
        #if defined TEST_SOLUTION
          SomeMockingFunction(code);
        #else
          Environment.Exit(code);
        #endif
    }
