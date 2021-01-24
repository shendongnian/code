    public void ShouldNotThrowException()
    {
        var objectUnderTest = new YourClass();
        Should.NotThrow(() => objectUnderTest.CheckModelDetail(null));
    }
