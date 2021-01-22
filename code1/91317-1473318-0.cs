    enum TestStateEnum { DISABLED, FAILED, SUCCEDED };
    TestStateEnum test1State = TestStateEnum.DISABLED;
    
    [Test]
    void Test1()
    {
    test1State =  TestStateEnum.FAILED; // On the beginning of your test
    ...
    test1State =  TestStateEnum.SUCCEDED; // On the End of your Test
    }
    
