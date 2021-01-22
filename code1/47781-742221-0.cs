    try
    {
        SomethingThatCausesAnException();
        Assert.Fail("Should have exceptioned above!");
    }
    catch (Exception ex)
    {
        // whatever logging code
    }
