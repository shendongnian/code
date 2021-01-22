    try 
    {
        SomeExceptionThrowingMethod()
        Assert.Fail("no exception thrown");
    }
    catch (Exception ex)
    {
        Assert.IsTrue(ex is SpecificExceptionType);
    }
