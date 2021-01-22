    [ExpectedException(typeof(ArgumentNullException), ExpectedMessage="Var1 is null, this cannot be!"]
    public void TestCaseOne {
        ...
    }
    
    [ExpectedException(typeof(ArgumentNullException), ExpectedMessage="Var2 is null, this cannot be either!"]
    public void TestCaseTwo {
        ...
    }
