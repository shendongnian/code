    [Test]
    void Test1()
    {
    test1State =  TestStateEnum.SUCCEDED; // On the beginning of your test
    try
    {
        ... // Your Test
    }
    catch( Exception )
    {
       test1State =  TestStateEnum.FAILED;
       throw; // Rethrows the Exception
    }
    }
